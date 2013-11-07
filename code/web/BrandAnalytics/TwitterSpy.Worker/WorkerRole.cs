using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using BrandAnalytics.Common;
using BrandAnalytics.Data;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using Streaminvi;
using TweetinCore.Events;
using TweetinCore.Interfaces;
using TweetinCore.Interfaces.StreamInvi;
using TweetinCore.Interfaces.TwitterToken;
using Tweetinvi;
using TwitterToken;

namespace TwitterSpy.Worker
{
    public class WorkerRole : RoleEntryPoint
    {

        private readonly List<TwitterSpyStudyData> _onGoingStudies = new List<TwitterSpyStudyData>();

        // The name of your queue

        private CloudQueue _queue;
        private CloudQueue _reportQueue;
        private CancellationTokenSource _cts;
        private IToken _token;
        private IFilteredStream _stream;
        private int _poolingWaitTime;
        private bool _isStreamStarted;

        public override void Run()
        {

            try
            {
                //
                //  This function can't be async so wait the termination of the async function
                //
                DoRun()
                    .Wait();

            }
            catch (Exception e)
            {
                if (_cts.IsCancellationRequested == false)
                {
                    //
                    //  Something went wrong on the run function
                    //
                    Trace.WriteLine("Run returned an exception:\n" + e);
                }
            }

        }

        private async Task DoRun()
        {
            Trace.WriteLine("Starting processing of messages");

            do
            {

                var message = await _queue.GetMessageAsync(_cts.Token);

                if (message == null)
                {
                    await Task.Delay(_poolingWaitTime);
                    continue;
                }


                var study = JsonConvert.DeserializeObject<TwitterStudy>(message.AsString);

                var reportData = StartStudy(study);

                StartTwitterStreamIfNeed();

                lock (_onGoingStudies)
                {
                    _onGoingStudies.Add(reportData);
                }

                await _queue.DeleteMessageAsync(message);

            } while (_cts.IsCancellationRequested);
        }

        private Timer t;
        private TwitterSpyStudyData StartStudy(TwitterStudy study)
        {
            var reportData = new TwitterSpyStudyData(study);

            Trace.WriteLine(string.Format("Study {0} started", study.Id));

            foreach (var topic in study.Topics)
            {
                _stream.AddTrack(topic, reportData.ProcessTweet);
            }

            

            // the object is stored so that the timer isn't garbage collected
            t = new Timer(o =>
            {
                var data = (TwitterSpyStudyData)o;


                //
                //  Remove the study from the ongoing list
                //
                lock (_onGoingStudies)
                {
                    _onGoingStudies.Remove(data);
                }

                CheckIfStreamNeedsToBeSuspended();

                //
                //  Remove topics
                //
                foreach (var topic in data.Study.Topics)
                {
                    _stream.RemoveTrack(topic);
                }

                var report = data.GetReport();

                //
                //  send report to the client via queue
                //
                _reportQueue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(report)));

               

            },
            reportData,
            study.Duration,
            TimeSpan.FromTicks(-1));

            return reportData;

        }

        private void CheckIfStreamNeedsToBeSuspended()
        {
            if (_onGoingStudies.Count != 0) 
                return;

            _stream.PauseStream();
        }


        private void StartTwitterStreamIfNeed()
        {

            if (_isStreamStarted)
            {
                if (_onGoingStudies.Count != 0)
                    _stream.ResumeStream();

                return;
            }

            

            _stream.StreamStarted += (s, a) => Trace.WriteLine("Stream has started!");

            _stream.LimitReached += (sender, args) => Trace.WriteLine(string.Format("You have missed {0} tweets because you were retrieving more than 1% of tweets", args.Value));

            TwitterContext context = new TwitterContext();

            if (!context.TryInvokeAction(() => _stream.StartStream(_token, tweet => Trace.Write("."))))
            {
                Trace.WriteLine(string.Format("An Exception occured : '{0}'", context.LastActionTwitterException.TwitterWebExceptionErrorDescription));
            }

            _isStreamStarted = true;
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            _queue = QueueUtils.GetOrCreateQueue("QueueConnectionString", QueuesContansts.TwitterSpyQueueName);
            _reportQueue = QueueUtils.GetOrCreateQueue("BrandeAnalyticsQueueConnectionString", QueuesContansts.BrandAnalyticsQueueName);

            _cts = new CancellationTokenSource();
            _poolingWaitTime = int.Parse(CloudConfigurationManager.GetSetting("PoolingWaitTime"));

            ConfigureTwitterClient();



            return base.OnStart();
        }



        private void ConfigureTwitterClient()
        {
            //
            //  In a real case scenario, this would be on the role config file,
            //  so that it could be possible to have 1 account for dev and 1 for production
            //
            _token = new Token(
                "229433152-tBsUWhkvxQ9tJ1IjXfZgmpLkYgh2yMTnCLQAQS07",
               "WudiIdI67pNbqFBcTOdb2LQmmMzMno8WwZBJHVHodIT8Q",
               "rBaq4UL4EFX7YZPab1OkQ",
                "v0rLnBWxbwk5oRXqwFTVMpGga6lRpy9DhQLU8pbrY");

            TokenSingleton.Token = _token;

            _stream = new FilteredStream();

        }

        public override void OnStop()
        {
            _cts.Cancel();
            base.OnStop();
        }
    }
}
