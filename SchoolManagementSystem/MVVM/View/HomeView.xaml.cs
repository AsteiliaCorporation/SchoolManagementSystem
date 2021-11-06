using LiveCharts;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementSystem.MVVM.View
{
    public partial class HomeView : UserControl
    {
        #region Global Variables

        private readonly string[] subjectNames = { "Bulgarian & Literature", "English", "German", "Mathematics", "IT", "History", "Geography", "Philosophy", "Biology", "Physics", "Chemistry", "Music", "Art", "PE" };

        private readonly ChartValues<double> subjectMarks = new ChartValues<double> { 5.0, 0.1, 0.1, 6.0, 0.1, 5.0, 3.0, 0.1, 4.0, 6.0, 6.0, 6.0, 0.1, 5.50 };

        #endregion

        public HomeView()
        {
            InitializeComponent();

            SetChartData();
        }

        private void UserControl_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            //Responsivize();
        }

        private void Responsivize()
        {
            if (Application.Current.MainWindow.Width < 800)
            {
                if (CubeGrid.RowDefinitions.Count == 0)
                {
                    CubeGrid.RowDefinitions.Add(new RowDefinition());
                    CubeGrid.RowDefinitions.Add(new RowDefinition());
                }

                int y = -1;

                for (int i = 0; i < 6; i++)
                {
                    if (i < 3)
                    {
                        Grid.SetRow(CubeGrid.Children[i], 0);
                        Grid.SetColumn(CubeGrid.Children[i], i);
                    }
                    if (i >= 3 && i < 6)
                    {
                        y++;

                        Grid.SetRow(CubeGrid.Children[i], 1);
                        Grid.SetColumn(CubeGrid.Children[i], y);
                    }
                }
            }
            else
            {
                if (CubeGrid.RowDefinitions.Count != 0)
                {
                    CubeGrid.RowDefinitions.Remove(new RowDefinition());
                    CubeGrid.RowDefinitions.Remove(new RowDefinition());
                }

                for (int i = 0; i < 6; i++)
                {
                    Grid.SetColumn(CubeGrid.Children[i], i);
                }
            }
        }

        private void  SetChartData()
        {
            columnSeries.Values = subjectMarks;

            xAxis.Labels = subjectNames;
            xAxis.MinHeight = 0d;
            xAxis.MaxHeight = 6d;
        }
    }
}
