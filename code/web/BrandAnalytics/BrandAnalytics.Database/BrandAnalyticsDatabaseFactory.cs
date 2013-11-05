using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Database
{
    public sealed class BrandAnalyticsDatabaseFactory
    {
        public static IBrandAnalyticsDatabase Instance { get; private set; }

        static BrandAnalyticsDatabaseFactory()
        {
            Instance = new InMemoryBrandAnalyticsDatabase();
        }
    }
}
