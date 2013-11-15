using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BrandAnalytics.Common;
using BrandAnalytics.Data;
using BrandAnalytics.Database;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Newtonsoft.Json;

namespace BrandAnalytics.Service
{
    public class WebRole : RoleEntryPoint
    {
        private const int TimeToDelay = 1000;
        private Task _messageListenerTask;

        public override bool OnStart()
        {
            // To enable the AzureLocalStorageTraceListner, uncomment relevent section in the web.config  
            DiagnosticMonitorConfiguration diagnosticConfig = DiagnosticMonitor.GetDefaultInitialConfiguration();
            diagnosticConfig.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1);
            diagnosticConfig.Directories.DataSources.Add(AzureLocalStorageTraceListener.GetLogDirectory());

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.


            _messageListenerTask = Task.Factory.StartNew(async () =>
            {
                var queue = QueueUtils.GetOrCreateQueue("BrandAnalyticsQueueConString",QueuesContansts.BrandAnalyticsQueueName);

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

            return base.OnStart();
        }
    }
}
