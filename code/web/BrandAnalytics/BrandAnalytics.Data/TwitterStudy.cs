using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandAnalytics.Data
{
    public enum TwitterStudyStates
    {
        Pending,
        Started,
        Completed,
        Revision,
        Canceled

    }

    public class TwitterStudy
    {
       
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public string Brand { get; set; }
        public TimeSpan Duration { get; set; }
        public string[] Topics { get; set; }
        public TwitterStudyStates CurrentState { get; set; }
        public TwitterStudyReport Report { get; set; }
    }

    public class TwitterStudyReport
    {
        public int Studyid { get; set; }
        public int NrOfTweets { get; set; }
        public int NrOfAuthors { get; set; }
        public string[] FrequentTerms { get; set; }
    }
}
