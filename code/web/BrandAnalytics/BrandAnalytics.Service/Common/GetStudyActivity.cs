using System.Activities;
using System.Linq;
using System.ServiceModel;
using BrandAnalytics.Data;
using BrandAnalytics.Database;

namespace BrandAnalytics.Service.Common
{

    public sealed class GetStudyActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> StudyId { get; set; }

        public OutArgument<TwitterStudy> Study { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var id = context.GetValue(this.StudyId);

            var study = BrandAnalyticsDatabaseFactory.Instance.Studies.GetAll().FirstOrDefault(s => s.Id.Equals(id));

            if (study == null)
                throw new FaultException(string.Format(ErrorMessages.StudyNotFoundMessage, id));

            context.SetValue(Study, study);
        }
    }
}
