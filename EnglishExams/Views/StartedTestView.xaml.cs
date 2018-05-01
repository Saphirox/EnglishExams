using System.Windows;
using System.Windows.Controls;
using EnglishExams.ViewModels;

namespace EnglishExams.Views
{
    /// <summary>
    /// Interaction logic for StartedTest.xaml
    /// </summary>
    public partial class StartedTestView : UserControl
    {
        public StartedTestView()
        {
            InitializeComponent();
        }

        private void OptionChecked(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            var dc = DataContext as StartedTestViewModel;

            dc.AddAnswer(dc.QuestionName, (string)checkbox.Content);
        }

        private void OptionUnchecked(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            var dc = DataContext as StartedTestViewModel;

            dc.RemoveAnswer(dc.QuestionName, (string)checkbox.Content);
        }
    }
}
