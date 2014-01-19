using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandAnalytics.Data;
using BrandAnalytics.Database.Mappers;

namespace BrandAnalytics.Database
{
    public interface IBrandAnalyticsDatabase
    {
        IEntityMapper<int, Client> Clients { get; }
        IEntityMapper<int, Employee> Employees { get; }
        IEntityMapper<int, TwitterStudy> Studies { get; }

    }
}
