using System;
using System.Windows.Input;

namespace SchoolManagementSystem.Core
{
    public abstract class BaseCommand : ICommand
    {
        #region Global Variables

        public event EventHandler CanExecuteChanged;

        #endregion

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
