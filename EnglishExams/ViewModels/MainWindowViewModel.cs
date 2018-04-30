using EnglishExams.Infrastructure;
using GalaSoft.MvvmLight.Messaging;

namespace EnglishExams.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value, nameof(CurrentViewModel));
        }

        public MainWindowViewModel()
        {
            RedirectDecorator.Register(this, ChangePage);

            CurrentViewModel = new LoginViewModel();
        }

        private void ShowSignUp()
        {
            CurrentViewModel = new SignUpViewModel();  
        }

        private void ShowMenu()
        {
            CurrentViewModel = new MenuViewModel();
        }

        private void ChangePage(ChangePage page)
        {
            if (typeof(SignUpViewModel) == page.CurrentViewModel)
            {
                this.ShowSignUp();
            }
            else if (typeof(MenuViewModel) == page.CurrentViewModel)
            {
                this.ShowMenu();
            }
        }
    }
}