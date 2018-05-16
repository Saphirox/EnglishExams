using System.Windows;
using EnglishExams.Infrastructure;
using EnglishExams.Resources;
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
            switch (CurrentUser.Instance.Role)
            {
                case Roles.Student:
                    RedirectDecorator.ToViewModel(typeof(TestListViewModel));
                    break;
                case Roles.Master:
                    MessageBox.Show(ErrorResources.TeacherCannotPassATest);
                    break;
            }
        }

        private void ShowGradebook()
        {
            if (CurrentUser.Instance.Role == Roles.Student)
            {
                RedirectDecorator.ToViewModel(typeof(GradebookViewModel));
            }
            else
            {
                // TODO: Add logic to master gradebook
            }
        }

        private void ShowCreateATest()
        {
            if (CurrentUser.Instance.Role == Roles.Master)
            {
                RedirectDecorator.ToViewModel(typeof(CreateTestViewModel));
            }
            else
            {
                MessageError.Show(ErrorResources.OnlyMasterCanCreateTests);
            }
        }

    }
}