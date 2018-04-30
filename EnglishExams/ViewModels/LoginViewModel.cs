using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using EnglishExams.Annotations;
using EnglishExams.Infrastructure;
using EnglishExams.Views;
using GalaSoft.MvvmLight.Messaging;

namespace EnglishExams.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _password;
        private string _login;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        
        public RelayCommand ShowSignUpPage { get; set; }
        public RelayCommand ShowMenuPage { get; set; }

        public LoginViewModel()
        {
            ShowSignUpPage = new RelayCommand(ShowSignUp);
            ShowMenuPage = new RelayCommand(ShowMenu);
        }

        private void ShowMenu()
        {
            // TODO: Add auth
            RedirectDecorator.ToViewModel(typeof(MenuViewModel));
        }

        private void ShowSignUp()
        {
            Messenger.Default.Send<ChangePage>(new ChangePage(typeof(SignUpViewModel)));
        }
        
    }
}