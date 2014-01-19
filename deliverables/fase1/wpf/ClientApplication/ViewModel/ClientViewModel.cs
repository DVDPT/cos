using System;
using System.Windows;
using System.Windows.Input;
using ClientApplication.ClientService;
using ClientApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

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
        private readonly IClientService _service;

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
        /// The <see cref="Brand" /> property's name.
        /// </summary>
        public const string BrandPropertyName = "Brand";

        private string _brand = string.Empty;

        /// <summary>
        /// Sets and gets the Brand property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Brand
        {
            get
            {
                return _brand;
            }

            set
            {
                if (_brand == value)
                {
                    return;
                }

                RaisePropertyChanging(BrandPropertyName);
                _brand = value;
                RaisePropertyChanged(BrandPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="StudyId" /> property's name.
        /// </summary>
        public const string StudyIdPropertyName = "StudyId";

        private int _studyId = 0;

        /// <summary>
        /// Sets and gets the StudyId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int StudyId
        {
            get
            {
                return _studyId;
            }

            set
            {
                if (_studyId == value)
                {
                    return;
                }

                RaisePropertyChanging(StudyIdPropertyName);
                _studyId = value;
                RaisePropertyChanged(StudyIdPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CompletedReports" /> property's name.
        /// </summary>
        public const string CompletedReportsPropertyName = "CompletedReports";

        private TwitterStudyReport[] _reports;

        /// <summary>
        /// Sets and gets the CompletedReports property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TwitterStudyReport[] CompletedReports
        {
            get
            {
                return _reports;
            }

            set
            {
                if (_reports == value)
                {
                    return;
                }

                RaisePropertyChanging(CompletedReportsPropertyName);
                _reports = value;
                RaisePropertyChanged(CompletedReportsPropertyName);
            }
        }

        public ClientViewModel(IClientService service)
        {
            _service = service;
            GetCompletedServicesCommand = new RelayCommand(GetCompletedServicesCommandImpl);
            CancelStudyCommand = new RelayCommand(CancelStudyCommandImpl);
            StartStudyCommand = new RelayCommand(StartStudyCommandImpl);
        }

        private async void CancelStudyCommandImpl()
        {
            try
            {

                await _service.CancelStudyAsync(new CancelStudyRequest(StudyId));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private async void StartStudyCommandImpl()
        {
            try
            {
                await _service.RequestStudyAsync(ClientId, Brand);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private async void GetCompletedServicesCommandImpl()
        {
            try
            {

                CompletedReports = await _service.GetCompletedStudiesAsync(ClientId);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public ICommand GetCompletedServicesCommand { get; set; }
        public ICommand StartStudyCommand { get; set; }
        public ICommand CancelStudyCommand { get; set; }

       
    }
}