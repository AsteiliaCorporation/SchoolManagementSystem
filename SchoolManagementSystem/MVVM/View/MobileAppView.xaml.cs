using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementSystem.MVVM.View
{
    public partial class MobileAppView : UserControl
    {
        public MobileAppView()
        {
            InitializeComponent();
        }

        private void GooglePlayBadgeButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://play.google.com/store/apps/details?id=com.shkolo.mobileapp");
        }

        private void AppleStoreBadgeButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://apps.apple.com/bg/app/shkolo/id1436156397");
        }
    }
}
