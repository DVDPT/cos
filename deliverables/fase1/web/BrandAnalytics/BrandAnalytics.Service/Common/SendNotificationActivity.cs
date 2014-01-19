using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace BrandAnalytics.Service.Common
{

    public sealed class SendNotificationActivity : CodeActivity
    {
        public InArgument<string> Email { get; set; }

        public InArgument<string> Subject { get; set; }

        public InArgument<string> Text { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            
        }
    }
}
