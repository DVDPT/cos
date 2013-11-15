using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using BrandAnalytics.Data;
using BrandAnalytics.Database;

namespace BrandAnalytics.Service.ServiceActivities.ClientService
{

    public sealed class GetCompletedStudiesActivity : CodeActivity
    {
        public InArgument<int> ClientId { get; set; }

        public OutArgument<TwitterStudyReport[]> Reports { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            context.SetValue(
                Reports,
                BrandAnalyticsDatabaseFactory.Instance.Studies.GetAll()
                .Where(s => s.CurrentState == TwitterStudyStates.Completed && s.ClientId == context.GetValue(ClientId))
                .Select(s => s.Report)
                .ToArray()
            );
        }
    }
}
