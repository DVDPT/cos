using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;
using BrandAnalytics.Common;
using BrandAnalytics.Data;
using BrandAnalytics.Database;
using Newtonsoft.Json;

namespace BrandAnalytics.Service.Common
{

    public sealed class StartQueueSubscriberIfNeeded : CodeActivity
    {

        private const int TimeToDelay = 1000;
        private Task _messageListenerTask;
        protected override void Execute(CodeActivityContext context)
        {
            if (_messageListenerTask != null)
                return;

            _messageListenerTask = Task.Factory.StartNew(async () =>
            {
                var queue = QueueUtils.GetOrCreateQueue("BrandAnalyticsQueueConString", QueuesContansts.BrandAnalyticsQueueName);

                do
                {
                    var msg = await queue.GetMessageAsync();

                    if (msg == null)
                    {
                        await Task.Delay(TimeToDelay);
                        continue;
                    }
                    var report = JsonConvert.DeserializeObject<TwitterStudyReport>(msg.AsString);

                    var study = BrandAnalyticsDatabaseFactory.Instance.Studies.GetAll()
                        .FirstOrDefault(s => s.Id.Equals(report.Studyid));


                    if (study == null)
                    {
                        Trace.WriteLine("Could not find study to set the report with id" + report.Studyid);
                        continue;
                    }

                    if (study.CurrentState != TwitterStudyStates.Canceled)
                    {
                        study.Report = report;
                        study.CurrentState = TwitterStudyStates.Revision;
                    }

                    await queue.DeleteMessageAsync(msg);

                } while (true);

            }, TaskCreationOptions.LongRunning);

        }
    }
}
