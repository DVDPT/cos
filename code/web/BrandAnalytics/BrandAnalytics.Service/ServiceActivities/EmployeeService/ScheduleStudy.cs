using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using BrandAnalytics.Common;
using BrandAnalytics.Data;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace BrandAnalytics.Service.ServiceActivities.EmployeeService
{

    public sealed class ScheduleStudy : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<TwitterStudy> Study { get; set; }
        public InArgument<Employee> Employee { get; set; }
        public InArgument<string[]> Topics { get; set; }
        public InArgument<TimeSpan> Duration { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var study = context.GetValue(this.Study);
            var duration = context.GetValue(this.Duration);
            var topics = context.GetValue(this.Topics);
            var employee = context.GetValue(this.Employee);

            var queue = QueueUtils.GetOrCreateQueue("TwitterSpyQueueConString", QueuesContansts.TwitterSpyQueueName);

            study.CurrentState = TwitterStudyStates.Started;
            study.EmployeeId = employee.Id;
            study.Duration = duration;
            study.Topics = topics;

            queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(study)));


        }
    }
}
