using System;
using System.ComponentModel;

namespace SchoolManagementSystem.MVVM.ViewModel
{
    public class NotifyViewModelBase : INotifyPropertyChanged
    {
        #region Global Variables

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void OnPropertyChangedEventHandler(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
