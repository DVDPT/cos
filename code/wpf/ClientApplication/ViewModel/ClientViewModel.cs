using GalaSoft.MvvmLight;

namespace ClientApplication.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ClientViewModel : AppViewModelBase
    {
        /// <summary>
        /// The <see cref="ClientId" /> property's name.
        /// </summary>
        public const string ClientIdPropertyName = "ClientId";

        private int _clientId = -1;

        /// <summary>
        /// Sets and gets the ClientId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ClientId
        {
            get
            {
                return _clientId;
            }

            set
            {
                if (_clientId == value)
                {
                    return;
                }

                RaisePropertyChanging(ClientIdPropertyName);
                _clientId = value;
                RaisePropertyChanged(ClientIdPropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the ClientViewModel class.
        /// </summary>
        public ClientViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}