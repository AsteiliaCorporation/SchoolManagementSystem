using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SchoolManagementSystem.Core
{
    public partial class ObservableObject : INotifyPropertyChanged
    {
        #region Global Variables

        public event PropertyChangedEventHandler PropertyChanged;


        #endregion

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
