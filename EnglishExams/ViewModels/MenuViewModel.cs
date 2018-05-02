using EnglishExams.Infrastructure;
using GalaSoft.MvvmLight.Messaging;

namespace EnglishExams.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public RelayCommand PassATest { get; set; }
        public RelayCommand Gradebook { get; set; }
        public RelayCommand CreateATest { get; set; }

        public MenuViewModel()
        {
            PassATest = new RelayCommand(ShowPassATest);
            Gradebook = new RelayCommand(ShowGradebook);
            CreateATest = new RelayCommand(ShowCreateATest);
        }

        private void ShowPassATest()
        {
            RedirectDecorator.ToViewModel(typeof(TestListViewModel));
        }

        private void ShowGradebook()
        {
            RedirectDecorator.ToViewModel(typeof(GradebookViewModel));
        }

        private void ShowCreateATest()
        {
            RedirectDecorator.ToViewModel(typeof(CreateTestViewModel));
        }

    }
}