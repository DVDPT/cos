using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.Model
{
    public interface IEmployeeService : EmployeeService.IService
    {
        
    }

    public class EmployeeServiceClient : EmployeeService.ServiceClient, IEmployeeService
    {
        public EmployeeServiceClient()
        {
        }

        public EmployeeServiceClient(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }

        public EmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        public EmployeeServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        public EmployeeServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        {
        }
    }
}
