using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandAnalytics.Data;
using BrandAnalytics.Database.Mappers;

namespace BrandAnalytics.Database
{
    public class InMemoryBrandAnalyticsDatabase : IBrandAnalyticsDatabase
    {
        private readonly InMemoryEntityMapper<int, Client> _clients;
        private readonly InMemoryEntityMapper<int, Employee> _employees;
        private readonly InMemoryEntityMapper<int, TwitterStudy> _studies;

        public IEntityMapper<int, Client> Clients { get { return _clients; } }
        public IEntityMapper<int, Employee> Employees { get { return _employees; } }
        public IEntityMapper<int, TwitterStudy> Studies { get { return _studies; } }

        public InMemoryBrandAnalyticsDatabase()
        {
            _clients = new InMemoryEntityMapper<int, Client>(c => c.Id);
            _employees = new InMemoryEntityMapper<int, Employee>(c => c.Id);
            _studies = new InMemoryEntityMapper<int, TwitterStudy>(c => c.Id);
            FillWithData();
        }

        private void FillWithData()
        {
            _clients.AddRange(new[]
            {
                new Client(){Id= 1, Email= "amet.dapibus.id@metusIn.org", Name= "Hodge"},
                new Client(){Id= 2, Email= "Etiam@pharetrautpharetra.ca", Name= "Gray"},
                new Client(){Id= 3, Email= "lobortis.Class@miDuisrisus.com", Name= "Mills"},
                new Client(){Id= 4, Email= "eu@per.co.uk", Name= "Bray"},
                new Client(){Id= 5, Email= "Aenean.massa@sodaleselit.net", Name= "Madden"},
                new Client(){Id= 6, Email= "amet@parturient.com", Name= "Hendrix"},
                new Client(){Id= 7, Email= "ac@Integer.com", Name= "Shields"},
                new Client(){Id= 8, Email= "mus.Donec@amet.ca", Name= "Ewing"},
                new Client(){Id= 9, Email= "neque.tellus.imperdiet@Duis.com", Name= "Chambers"},
                new Client(){Id= 10, Email= "nisi@risus.org", Name= "Bright"}
            });

            _employees.AddRange(new[]
            {
                new Employee(){Id= 80, Email= "fames@odioPhasellusat.edu", Name= "Harding"},
                new Employee(){Id= 81, Email= "eu@nislelementum.edu", Name= "Guzman"},
                new Employee(){Id= 82, Email= "ac.turpis@ligulaAeneangravida.edu", Name= "Guerrero"},
                new Employee(){Id= 83, Email= "gravida@variusNam.org", Name= "Bass"},
                new Employee(){Id= 84, Email= "arcu.iaculis@diam.edu", Name= "Alvarado"},
                new Employee(){Id= 85, Email= "augue.Sed@risus.org", Name= "Casey"},
                new Employee(){Id= 86, Email= "lobortis.nisi.nibh@semperauctorMauris.net", Name= "Whitehead"},
                new Employee(){Id= 87, Email= "Nullam.velit@dolor.ca", Name= "Berger"},
                new Employee(){Id= 88, Email= "dis.parturient.montes@sapien.edu", Name= "Merrill"},
                new Employee(){Id= 89, Email= "ornare@elitpellentesquea.com", Name= "Atkins"},
                new Employee(){Id= 90, Email= "malesuada.fames@nisi.com", Name= "Parsons"}
            });

            _studies.AddRange(new[]
            {
                new TwitterStudy
                {
                    ClientId = 1, CurrentState = TwitterStudyStates.Canceled, Duration = TimeSpan.FromDays(2),EmployeeId = 80,Id = 1,Topics = new[]{"wp","wpdev"}
                }, 
                new TwitterStudy
                {
                    ClientId = 1, CurrentState = TwitterStudyStates.Pending, EmployeeId = 80,Id = 2
                }, 
            });
        }
    }
}
