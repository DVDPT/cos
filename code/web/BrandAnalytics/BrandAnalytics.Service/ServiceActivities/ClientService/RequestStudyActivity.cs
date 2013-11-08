using System.Activities;
using BrandAnalytics.Data;
using BrandAnalytics.Database;

namespace BrandAnalytics.Service.ServiceActivities.ClientService
{
    public sealed class RequestStudyActivity : CodeActivity
    {
        public InArgument<int> ClientId { get; set; }
        public InArgument<string> Brand { get; set; }
        public OutArgument<int> StudyId { get; set; }
        
        protected override void Execute(CodeActivityContext context)
        {
            context.SetValue(StudyId,
                BrandAnalyticsDatabaseFactory.Instance.Studies.Add(new TwitterStudy()
                {
                      ClientId = context.GetValue(ClientId),
                      Brand = context.GetValue(Brand)
                }));
        }
    }
}
