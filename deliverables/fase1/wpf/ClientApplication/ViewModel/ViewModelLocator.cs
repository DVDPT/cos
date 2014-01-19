/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ClientApplication"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using ClientApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ClientApplication.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

#if DEBUG
            SimpleIoc.Default.Register<IEmployeeService>(() => new EmployeeServiceClient("LocalEndpointEmployee"));
            SimpleIoc.Default.Register<IClientService>(() => new ClientServiceClient("LocalEndpointClient"));
#else
            SimpleIoc.Default.Register<IEmployeeService>(() => new EmployeeServiceClient("CloudEndpointEmployee"));
            SimpleIoc.Default.Register<IClientService>(() => new ClientServiceClient("CloudEndpointClient"));

#endif

            SimpleIoc.Default.Register<ClientViewModel>();
            SimpleIoc.Default.Register<EmployeeViewModel>();
        }

        public ClientViewModel ClientViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ClientViewModel>();
            }
        }

        public EmployeeViewModel EmployeeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EmployeeViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}