using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace BrandAnalytics.Common
{
    public static class QueuesContansts
    {
       public const string TwitterSpyQueueName = "twitterspyserviceaueue";
       public const string BrandAnalyticsQueueName = "brandanalyticsservicequeue";
    }

    public static class QueueUtils
    {
        public static CloudQueue GetOrCreateQueue(string connectionString, string queueName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(connectionString));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);
            queue.CreateIfNotExists();
            return queue;
        }
    }
}
