using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Activities;
using BrandAnalytics.Data;
using BrandAnalytics.Database;

namespace BrandAnalytics.Common
{

    public sealed class GetEmployeeActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> EmployeeId { get; set; }
        public OutArgument<Employee> Employee { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var id = context.GetValue(EmployeeId);
            var employee = BrandAnalyticsDatabaseFactory.Instance.Employees.Get(id);

            if (employee == null)
                throw new FaultException(string.Format(ErrorMessages.EmployeeNotFoundMessage, id));

            context.SetValue(Employee, employee);
        }
    }
}
