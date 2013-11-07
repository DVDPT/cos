﻿using System.Activities;
using BrandAnalytics.Data;
using BrandAnalytics.Database;

namespace BrandAnalytics.Service.Common
{
    public sealed class GetClientActivity : CodeActivity
    {
        public InArgument<int> ClientId { get; set; }

        public OutArgument<Client> Client { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            context.SetValue(this.Client, BrandAnalyticsDatabaseFactory.Instance.Clients.Get(context.GetValue(this.ClientId)));
        }
    }
}
