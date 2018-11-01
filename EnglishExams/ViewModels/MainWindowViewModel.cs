using System;
using System.Windows;
using EnglishExams.Infrastructure;

namespace EnglishExams.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public RelayCommand Logout { get; set; }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value, nameof(CurrentViewModel));
        }

        public Visibility LogoutVisibility => CurrentUser.IsAuthenticated() ? Visibility.Visible: Visibility.Hidden;

        public MainWindowViewModel()
        {
            RedirectDecorator.Register(this, ChangePage);
            OnPropertyChanged(nameof(LogoutVisibility));
            CurrentViewModel = new LoginViewModel();
            Logout = new RelayCommand(ShowSignIn);
        }

        public void ShowSignIn()
        {
            CurrentUser.Instance = null;
            OnPropertyChanged(nameof(LogoutVisibility));
            CurrentViewModel = new LoginViewModel();
        }

        private void ChangePage(ChangePage page)
        {
            var vm = NinjectFactory.GetInstance().GetService(page.CurrentViewModel) as ViewModelBase;

            if (vm is null)
                throw new InvalidOperationException("Current view model does not exist");

            OnPropertyChanged(nameof(LogoutVisibility));

            CurrentViewModel = vm ?? throw new InvalidCastException(nameof(page.CurrentViewModel));
        }
    }
}