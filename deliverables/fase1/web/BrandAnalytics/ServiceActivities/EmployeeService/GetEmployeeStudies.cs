using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using BrandAnalytics.Data;
using BrandAnalytics.Database;

namespace BrandAnalytics.ServiceActivities.EmployeeService
{

    public sealed class GetEmployeeStudies : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<Employee> Employee { get; set; }
        public OutArgument<TwitterStudy[]> Studies { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var employee = context.GetValue(Employee);

            var studies = BrandAnalyticsDatabaseFactory.Instance.Studies.GetAll()
                .Where(s => s.CurrentState == TwitterStudyStates.Pending || s.EmployeeId == employee.Id).ToArray();

            context.SetValue(Studies, studies);
        }
    }
}
