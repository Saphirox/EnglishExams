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

            var textBlock = (TextBlock) checkbox.Content;

            dc.AddAnswer(dc.QuestionName, textBlock.Text);
        }

        private void OptionUnchecked(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            var dc = DataContext as StartedTestViewModel;
            var textBlock = (TextBlock)checkbox.Content;

            dc.RemoveAnswer(dc.QuestionName, textBlock.Text);
        }
    }
}
