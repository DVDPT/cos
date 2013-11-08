using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using BrandAnalytics.Database;

namespace BrandAnalytics.Service.ServiceActivities.ClientService
{

    public sealed class CancelStudyActivity : CodeActivity
    {
        public InArgument<int> StudyId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            BrandAnalyticsDatabaseFactory.Instance.Studies.Get(context.GetValue(StudyId)).CurrentState = Data.TwitterStudyStates.Canceled;
        }
    }
}
