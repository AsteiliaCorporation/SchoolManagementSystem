using System;
using System.Windows;
using Forms = System.Windows.Forms;
using System.Drawing;
using SchoolManagementSystem.MVVM.ViewModel;
using SchoolManagementSystem.Core;
using SchoolManagementSystem.Classes;

namespace SchoolManagementSystem
{
    public partial class App : Application
    {
        #region Global Variables

        private readonly Forms.NotifyIcon notifyIcon;

        private Theme theme;
        private AutoStart autoStart;

        #endregion

        public App()
        {
            notifyIcon = new Forms.NotifyIcon();
            theme = new Theme();
            autoStart = new AutoStart();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            notifyIcon.Icon = new Icon("D:/Projects/Visual Studio/SchoolManagementSystem/SchoolManagementSystem/Icons/icon.ico");
            notifyIcon.Text = "Asteilia";
            notifyIcon.Click += NotifyIcon_Click;

            notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripDropDownButton("My status",
                Image.FromFile("D:/Projects/Visual Studio/SchoolManagementSystem/SchoolManagementSystem/Icons/icon.ico"),
                new Forms.ToolStripButton("Available")));
            notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add("Sign out", Image.FromFile("D:/Projects/Visual Studio/SchoolManagementSystem/SchoolManagementSystem/Icons/icon.ico"), OnSignOut_Click);
            notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add("Settings", Image.FromFile("D:/Projects/Visual Studio/SchoolManagementSystem/SchoolManagementSystem/Icons/icon.ico"), OnSettings_Click);
            notifyIcon.ContextMenuStrip.Items.Add("Quit", Image.FromFile("D:/Projects/Visual Studio/SchoolManagementSystem/SchoolManagementSystem/Icons/icon.ico"), OnQuit_Click);

            notifyIcon.Visible = true;

            theme.WatchTheme();
            autoStart.AutoStartUp();

            ShowNotification();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            notifyIcon.Dispose();

            base.OnExit(e);
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            MainWindow.WindowState = WindowState.Normal;
            MainWindow.Activate();
        }

        private void OnMyStatus_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnSignOut_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)MainWindow;
            MainViewModel mainViewModel = new MainViewModel();

            mainWindow.contentControl.Content = mainViewModel.AuthorizationVM;
        }

        private void OnSettings_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = (MainWindow)MainWindow;
            MainViewModel mainViewModel = new MainViewModel();

            mainWindow.contentControl.Content = mainViewModel.SettingsVM;
        }

        private void OnQuit_Click(object sender, EventArgs e)
        {
            MainWindow.Close();
        }

        public void ShowNotification()
        {
            NotifyCommand notifyCommand = new NotifyCommand(notifyIcon);
            notifyCommand.Execute(null);
        }
    }
}
