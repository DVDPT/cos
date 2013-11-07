using System.Activities;
using BrandAnalytics.Data;

namespace BrandAnalytics.Service.ServiceActivities.ClientService
{

    public sealed class RequestStudyForClientActivity : CodeActivity
    {
        public InArgument<Client> Client { get; set; }
        public InArgument<string> Brand { get; set; }
        public OutArgument<int> StudyId { get; set; }
        
        protected override void Execute(CodeActivityContext context)
        {
            
        }
    }
}
