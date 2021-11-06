using SchoolManagementSystem.MVVM.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace SchoolManagementSystem.MVVM.View
{
    public partial class PrimaryView : UserControl
    {
        #region Global Variables

        private bool isMenuOpened = false;
        private bool widthAnimationCompleted = true;

        private DoubleAnimation widthAnimation;
        private DoubleAnimation opacityAnimation;

        private RadioButton radioButton;

        private readonly MainViewModel mainViewModel;

        private readonly MainWindow mainWindow;

        #endregion

        public PrimaryView()
        {
            InitializeComponent();

            mainViewModel = new MainViewModel();
            mainWindow = (MainWindow)Application.Current.MainWindow;

            contentControl.Content = mainViewModel.HomeVM;
            homeRadioButton.IsChecked = true;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            widthAnimation = new DoubleAnimation();
            widthAnimation.Completed += new EventHandler(MenuAnimation_Completed);
            widthAnimation.Duration = new Duration(TimeSpan.Parse("00:00:00.25"));
            widthAnimation.DecelerationRatio = 0.5d;
            widthAnimation.AccelerationRatio = 0.5d;

            if (Application.Current.MainWindow.Width <= 1000 && isMenuOpened && widthAnimationCompleted)
            {
                #region Menu Storyboard

                widthAnimation.From = Menu.ActualWidth;
                widthAnimation.To = 50;

                Storyboard.SetTargetName(widthAnimation, Menu.Name);
                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(ColumnDefinition.MaxWidthProperty));

                Storyboard menuWidthAnimationStoryboard = new Storyboard();
                menuWidthAnimationStoryboard.Children.Add(widthAnimation);

                menuWidthAnimationStoryboard.Begin(Menu);

                #endregion

                #region Logo Storyboard

                widthAnimation.From = Logo.ActualWidth;
                widthAnimation.To = 50;

                Storyboard.SetTargetName(widthAnimation, Logo.Name);
                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(ColumnDefinition.MaxWidthProperty));

                menuWidthAnimationStoryboard.Children.Add(widthAnimation);

                menuWidthAnimationStoryboard.Begin(Logo);

                LogoName.Text = "A";

                #endregion

                MenuScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;

                isMenuOpened = false;
                widthAnimationCompleted = false;
            }
            else if (Application.Current.MainWindow.Width > 1000 && !isMenuOpened && widthAnimationCompleted)
            {
                #region Menu Storyboard

                widthAnimation.From = 50;
                widthAnimation.To = 235;

                Storyboard.SetTargetName(widthAnimation, Menu.Name);
                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(ColumnDefinition.MaxWidthProperty));

                Storyboard menuWidthAnimationStoryboard = new Storyboard();
                menuWidthAnimationStoryboard.Children.Add(widthAnimation);

                menuWidthAnimationStoryboard.Begin(Menu);

                #endregion

                #region Logo Storyboard

                widthAnimation.From = 50;
                widthAnimation.To = 235;

                Storyboard.SetTargetName(widthAnimation, Logo.Name);
                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(ColumnDefinition.MaxWidthProperty));

                menuWidthAnimationStoryboard.Children.Add(widthAnimation);

                menuWidthAnimationStoryboard.Begin(Logo);

                LogoName.Text = "A S T E I L I A";

                #endregion

                MenuScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

                isMenuOpened = true;
                widthAnimationCompleted = false;
            }
        }

        private void Logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (contentControl.Content != mainViewModel.HomeVM)
            {
                homeRadioButton.IsChecked = true;
            }
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (contentControl.Content != mainViewModel.AccountVM)
            {
                radioButton.IsChecked = false;
                FadeInOut();
                contentControl.Content = mainViewModel.AccountVM;
            }
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.contentControl.Content = mainViewModel.AuthorizationVM;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            radioButton = (RadioButton)sender;

            if (radioButton.IsChecked == true)
            {
                switch (radioButton.Name)
                {
                    case "homeRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.HomeVM;
                        break;
                    case "logbookRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.LogbookVM;
                        break;
                    case "tasksRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.TasksVM;
                        break;
                    case "statisticsRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.StatisticsVM;
                        break;
                    case "activitiesRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.ActivitiesVM;
                        break;
                    case "materialsRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.MaterialsVM;
                        break;
                    case "testsRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.TestsVM;
                        break;
                    case "eventsRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.EventsVM;
                        break;
                    case "competitionsRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.CompetitionsVM;
                        break;
                    case "officeWorkRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.OfficeWorkVM;
                        break;
                    case "administrationRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.AdministrationVM;
                        break;
                    case "mobileAppRadioButton":
                        FadeInOut();
                        contentControl.Content = mainViewModel.MobileAppVM;
                        break;
                    default:
                        break;
                }
            }
        }

        private void GuideButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.shkolo.bg/blog/help/");
        }

        private void MenuAnimation_Completed(object sender, EventArgs e)
        {
            widthAnimationCompleted = true;
        }

        private void FadeInOut()
        {
            opacityAnimation = new DoubleAnimation();
            opacityAnimation.Completed += new EventHandler(MenuAnimation_Completed);
            opacityAnimation.Duration = new Duration(TimeSpan.Parse("00:00:00.40"));
            opacityAnimation.DecelerationRatio = 0.5d;
            opacityAnimation.AccelerationRatio = 0.5d;

            #region Content Storyboard

            opacityAnimation.From = 1;
            opacityAnimation.To = 0;

            Storyboard.SetTargetName(opacityAnimation, contentControl.Name);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(OpacityProperty));

            Storyboard contentOpacityAnimationStoryboard = new Storyboard();
            contentOpacityAnimationStoryboard.Children.Add(opacityAnimation);

            contentOpacityAnimationStoryboard.Begin(contentControl);

            opacityAnimation.From = 0;
            opacityAnimation.To = 1;

            contentOpacityAnimationStoryboard.Children.Add(opacityAnimation);

            contentOpacityAnimationStoryboard.Begin(contentControl);

            #endregion
        }
    }
}
