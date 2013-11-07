using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandAnalytics.Data;
using TweetinCore.Interfaces;

namespace TwitterSpy.Worker
{
    public class TwitterSpyStudyData
    {
        private const int NrOfFrequentElements = 25;

        public TwitterStudy Study { get; set; }

        public Dictionary<string, int> Histogram { get; private set; }
        public HashSet<string> Authors { get; private set; }

        public int TweetsCount { get; private set; }

        public TwitterSpyStudyData(TwitterStudy study)
        {
            Study = study;
            Histogram = new Dictionary<string, int>();
            Authors = new HashSet<string>();
        }

        public void ProcessTweet(ITweet tweet)
        {
            lock (this)
            {
                var hashtags = tweet.Hashtags.Select(h => h.Text);

                foreach (var hashtag in hashtags)
                {
                    if (Histogram.ContainsKey(hashtag))
                    {
                        Histogram[hashtag]++;
                    }
                    else
                    {
                        Histogram.Add(hashtag, 1);
                    }
                }

                TweetsCount++;
                Authors.Add(tweet.Creator.Name);
            }
        }

        public TwitterStudyReport GetReport()
        {
            return new TwitterStudyReport
            {
                Studyid = Study.Id,
                NrOfAuthors = Authors.Count,
                NrOfTweets = TweetsCount,
                FrequentTerms = Histogram.OrderByDescending(h => h.Value).Take(NrOfFrequentElements).Select(o => o.Key).ToArray()
            };
        }
    }
}
