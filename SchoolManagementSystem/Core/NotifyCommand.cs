using System;
using System.Windows.Forms;

namespace SchoolManagementSystem.Core
{
    public class NotifyCommand : BaseCommand
    {
        #region Global Variables

        private readonly NotifyIcon notifyIcon;

        #endregion

        public NotifyCommand(NotifyIcon _notifyIcon)
        {
            notifyIcon = _notifyIcon;
        }

        public override void Execute(object parameter)
        {
            notifyIcon.ShowBalloonTip(3000, "Asteilia", "Be sure to subscribe!", ToolTipIcon.Info);
        }
    }
}
