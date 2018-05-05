using System.Windows;
using System.Windows.Controls;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.ViewModels;

namespace EnglishExams.Views
{
    /// <summary>
    /// Interaction logic for Gradebook.xaml
    /// </summary>
    public partial class Gradebook : UserControl
    {
        public Gradebook()
        {
            InitializeComponent();
        }

        private void ListBoxHander(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            var st = ButtonAttachedProperty.GetUnitName(button);

            var dc = DataContext as GradebookViewModel;

            dc.ShowConcreteLesson(new TestDescription
            {
                UnitName = ButtonAttachedProperty.GetUnitName(button),
                LessonName = ButtonAttachedProperty.GetLessonName(button)
            });
        }
    }
}
