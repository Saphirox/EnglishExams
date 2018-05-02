using System.Windows;
using System.Windows.Controls;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.ViewModels;

namespace EnglishExams.Views
{
    /// <summary>
    /// Interaction logic for TestList.xaml
    /// </summary>
    public partial class TestListView : UserControl
    {
        public TestListView()
        {
            InitializeComponent();
        }

        private void ListBoxHander(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            var st = ButtonAttachedProperty.GetUnitName(button);

            var dc = DataContext as TestListViewModel;

            dc.StartTest(new TestDescription
            {
                UnitName = st,
                LessonName = (string)button.Content
            });
        }
    }
}
