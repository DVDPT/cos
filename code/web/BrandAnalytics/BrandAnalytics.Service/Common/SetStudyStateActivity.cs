using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using BrandAnalytics.Database;
using BrandAnalytics.Data;

namespace BrandAnalytics.Service.Common
{

    public sealed class SetStudyStateActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> StudyId { get; set; }

        public InArgument<TwitterStudyStates> State { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            BrandAnalyticsDatabaseFactory.Instance.Studies.Get(context.GetValue(StudyId)).CurrentState = context.GetValue(State);
        }
    }
}
