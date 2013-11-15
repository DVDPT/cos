using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ClientApplication.ViewModel
{
    public class AppViewModelBase : ViewModelBase
    {
        /// <summary>
        /// The <see cref="LoadingMessage" /> property's name.
        /// </summary>
        public const string LoadingMessagePropertyName = "LoadingMessage";

        private string _loadingMessage = string.Empty;

        /// <summary>
        /// Sets and gets the LoadingMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LoadingMessage
        {
            get
            {
                return _loadingMessage;
            }

            set
            {
                if (_loadingMessage == value)
                {
                    return;
                }

                RaisePropertyChanging(LoadingMessagePropertyName);
                _loadingMessage = value;
                RaisePropertyChanged(LoadingMessagePropertyName);
            }
        }


        public void StartOperation(string oper)
        {
            LoadingMessage = oper;
        }

        public void StopOperation()
        {
            LoadingMessage = string.Empty;
        }
    }
}
