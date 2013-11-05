using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using BrandAnalytics.Data;

namespace BrandAnalytics.ServiceActivities.ClientService
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
