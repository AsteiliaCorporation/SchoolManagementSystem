using SchoolManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SchoolManagementSystem.MVVM.View
{
    public partial class LogbookView : UserControl
    {
        private int subjectNumber;

        public LogbookView()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            List<Subject> items = new List<Subject>
            {
                new Subject(++subjectNumber, "📖 Bulgarian & Literature", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 English", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 German", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Mathematics", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Information Technology", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 History", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Geography & Economy", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Philosophy", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Biology & Healthcare", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Physics & Astronomy", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Chemistry & Environmental Safety", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Music", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Art", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Phisical Education", 5.50, 0, 0, 0),
                new Subject(++subjectNumber, "📖 Informatics", 5.50, 0, 0, 0)
            };

            DataGrid grid = sender as DataGrid;
            grid.ItemsSource = items;
        }
    }
}
