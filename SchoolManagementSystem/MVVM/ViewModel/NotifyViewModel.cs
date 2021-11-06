using SchoolManagementSystem.Core;
using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace SchoolManagementSystem.MVVM.ViewModel
{
    public partial class NotifyViewModel : NotifyViewModelBase
    {
        public ICommand NotifyCommand { get; }

        public NotifyViewModel(NotifyIcon _notifyIcon)
        {
            NotifyCommand = new NotifyCommand(_notifyIcon);
        }
    }
}
