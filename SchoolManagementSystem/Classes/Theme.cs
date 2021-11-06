using System;
using System.Security.Principal;
using System.Globalization;
using System.Management;
using Microsoft.Win32;
using System.Windows;

namespace SchoolManagementSystem.Classes
{
    internal class Theme
    {
        #region Global Variables

        private const string REGISTRY_KEY_PATH = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        private const string REGISTRY_VALUE_NAME = "AppsUseLightTheme";

        #endregion

        private enum WindowsTheme
        {
            Light,
            Dark
        }

        public void WatchTheme()
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            string query = string.Format(
                CultureInfo.InvariantCulture,
                @"SELECT * FROM RegistryValueChangeEvent WHERE Hive = 'HKEY_USERS' AND KeyPath = '{0}\\{1}' AND ValueName = '{2}'",
                currentUser.User.Value,
                REGISTRY_KEY_PATH.Replace(@"\", @"\\"),
                REGISTRY_VALUE_NAME);

            try
            {
                ManagementEventWatcher watcher = new ManagementEventWatcher(query);
                watcher.EventArrived += (sender, args) =>
                {
                    WindowsTheme newWindowsTheme = GetWindowsTheme();

                    //- On Theme Changed
                    if (GetWindowsTheme() == WindowsTheme.Light)
                    {
                        Application.Current.Resources.MergedDictionaries[15].Source = new Uri($"/Themes/Light.xaml", UriKind.Relative);
                    }
                    else if (GetWindowsTheme() == WindowsTheme.Dark)
                    {
                        Application.Current.Resources.MergedDictionaries[15].Source = new Uri($"/Themes/Dark.xaml", UriKind.Relative);
                    }
                };

                watcher.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            WindowsTheme initialTheme = GetWindowsTheme();
        }

        private static WindowsTheme GetWindowsTheme()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY_PATH))
            {
                object registryValueObject = key?.GetValue(REGISTRY_VALUE_NAME);
                if (registryValueObject == null)
                {
                    return WindowsTheme.Light;
                }

                int registryValue = (int)registryValueObject;

                return registryValue > 0 ? WindowsTheme.Light : WindowsTheme.Dark;
            }
        }
    }
}
