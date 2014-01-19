using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using ClientApplication.ClientService;

namespace ClientApplication.Model
{
    public interface IClientService : IService
    {

    }

    public class ClientServiceClient : ServiceClient, IClientService
    {
        public ClientServiceClient()
        {
        }

        public ClientServiceClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        {
        }

        public ClientServiceClient(string endpointConfigurationName, string remoteAddress)
            : base(endpointConfigurationName, remoteAddress)
        {
        }

        public ClientServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress)
            : base(endpointConfigurationName, remoteAddress)
        {
        }

        public ClientServiceClient(Binding binding, EndpointAddress remoteAddress)
            : base(binding, remoteAddress)
        {
        }
    }
}
