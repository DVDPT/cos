using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClientApplication.EmployeeService;
using ClientApplication.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ClientApplication.ViewModel
{
    public class EmployeeViewModel : AppViewModelBase
    {
        private readonly IEmployeeService _service;


        /// <summary>
        /// The <see cref="EmployeeId" /> property's name.
        /// </summary>
        public const string EmployeeIdPropertyName = "EmployeeId";

        private int _employeeId = -1;

        /// <summary>
        /// Sets and gets the EmployeeId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int EmployeeId
        {
            get
            {

                return _employeeId;
            }

            set
            {
                if (_employeeId == value)
                {
                    return;
                }

                RaisePropertyChanging(EmployeeIdPropertyName);
                _employeeId = value;
                RaisePropertyChanged(EmployeeIdPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Studies" /> property's name.
        /// </summary>
        public const string StudiesPropertyName = "Studies";

        private TwitterStudy[] _studies;

        /// <summary>
        /// Sets and gets the Studies property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TwitterStudy[] Studies
        {
            get
            {
                return _studies;
            }

            set
            {
                if (_studies == value)
                {
                    return;
                }

                RaisePropertyChanging(StudiesPropertyName);
                _studies = value;
                RaisePropertyChanged(StudiesPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CurrentStudy" /> property's name.
        /// </summary>
        public const string CurrentStudyPropertyName = "CurrentStudy";

        private TwitterStudy _study = null;

        /// <summary>
        /// Sets and gets the CurrentStudy property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TwitterStudy CurrentStudy
        {
            get
            {
                return _study;
            }

            set
            {
                if (_study == value)
                {
                    return;
                }

                RaisePropertyChanging(CurrentStudyPropertyName);
                _study = value;
                CurrentStudyChanged();
                RaisePropertyChanged(CurrentStudyPropertyName);
            }
        }



        /// <summary>
        /// The <see cref="Topics" /> property's name.
        /// </summary>
        public const string TopicsPropertyName = "Topics";

        private string _topics = string.Empty;

        /// <summary>
        /// Sets and gets the Topics property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Topics
        {
            get
            {
                return _topics;
            }

            set
            {
                if (_topics == value)
                {
                    return;
                }

                RaisePropertyChanging(TopicsPropertyName);
                _topics = value;
                RaisePropertyChanged(TopicsPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Time" /> property's name.
        /// </summary>
        public const string TimePropertyName = "Time";

        private TimeSpan _time = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Sets and gets the Time property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan Time
        {
            get
            {
                return _time;
            }

            set
            {
                if (_time == value)
                {
                    return;
                }

                RaisePropertyChanging(TimePropertyName);
                _time = value;
                RaisePropertyChanged(TimePropertyName);
            }
        }

        public EmployeeViewModel(IEmployeeService service)
        {
            _service = service;
            GetEmployeeDetailsCommand = new RelayCommand(() => LoadEmployeeData());
            StartStudyCommand = new RelayCommand(StartStudy);
        }


        public ICommand GetEmployeeDetailsCommand { get; set; }
        public ICommand StartStudyCommand { get; set; }
        private async Task LoadEmployeeData()
        {
            StartOperation("Getting employee studies");

            Studies = new TwitterStudy[0];
            try
            {
                Studies = await _service.GetPendingStudiesAsync(EmployeeId);
            }
            catch (Exception e)
            {
            }

            StopOperation();
        }


        private async void StartStudy()
        {
            if (CurrentStudy == null || (CurrentStudy.CurrentState != TwitterStudyStates.Pending &&
                CurrentStudy.CurrentState != TwitterStudyStates.Revision))
            {
                MessageBox.Show("Only can start a service when it is pending or in a revision");
                return;
            }

            StartOperation("Starting Study");
            try
            {
                await
                    _service.StartStudyAsync(new StartStudyRequest(CurrentStudy.Id, Topics.Split(','), Time, EmployeeId));
                await LoadEmployeeData();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
            StopOperation();
        }

        private void CurrentStudyChanged()
        {
            if (CurrentStudy == null)
                return;

            if (CurrentStudy.Topics != null && CurrentStudy.Topics.Length != 0)
            {
                Topics = CurrentStudy.Topics.Aggregate((first, second) => first + "," + second);
            }
            else
            {
                Topics = string.Empty;
            }

            if (CurrentStudy.Duration > TimeSpan.FromMinutes(1))
                Time = CurrentStudy.Duration;
            else
            {
                Time = TimeSpan.FromMinutes(1);
            }
        }
    }
}
