using System;
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

        private void ChangePage(ChangePage page)
        {
            var vm = Activator.CreateInstance(page.CurrentViewModel) as ViewModelBase;

            CurrentViewModel = vm ?? throw new InvalidCastException(nameof(page.CurrentViewModel));
        }
    }
}