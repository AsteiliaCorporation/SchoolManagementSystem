using SchoolManagementSystem.MVVM.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementSystem.MVVM.View
{
    public partial class SettingsView : UserControl
    {
        #region Global Variables

        private RadioButton radioButton;

        private MainViewModel mainViewModel;

        #endregion

        public SettingsView()
        {
            InitializeComponent();

            mainViewModel = new MainViewModel();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            radioButton = (RadioButton)sender;

            if (radioButton.IsChecked == true)
            {
                switch (radioButton.Name)
                {
                    case "homeRadioButton":
                        contentControl.Content = mainViewModel.HomeVM;
                        break;
                    case "logbookRadioButton":
                        contentControl.Content = mainViewModel.LogbookVM;
                        break;
                    case "tasksRadioButton":
                        contentControl.Content = mainViewModel.TasksVM;
                        break;
                    case "statisticsRadioButton":
                        contentControl.Content = mainViewModel.StatisticsVM;
                        break;
                    case "activitiesRadioButton":
                        contentControl.Content = mainViewModel.ActivitiesVM;
                        break;
                    case "materialsRadioButton":
                        contentControl.Content = mainViewModel.MaterialsVM;
                        break;
                    case "testsRadioButton":
                        contentControl.Content = mainViewModel.TestsVM;
                        break;
                    case "eventsRadioButton":
                        contentControl.Content = mainViewModel.EventsVM;
                        break;
                    case "competitionsRadioButton":
                        contentControl.Content = mainViewModel.CompetitionsVM;
                        break;
                    case "officeWorkRadioButton":
                        contentControl.Content = mainViewModel.OfficeWorkVM;
                        break;
                    case "administrationRadioButton":
                        contentControl.Content = mainViewModel.AdministrationVM;
                        break;
                    case "mobileAppRadioButton":
                        contentControl.Content = mainViewModel.MobileAppVM;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
