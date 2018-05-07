using System;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;
using GalaSoft.MvvmLight.Messaging;

namespace EnglishExams.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IUserService _userService = 
            new UserService(new FileWrapper());

        private UserModel _userModel = new UserModel();

        public string Password
        {
            get => _userModel.Password;
            set
            {
                _userModel.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        
        public string Login
        {
            get => _userModel.UserName;
            set
            {
                _userModel.UserName = value;
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
            _userService.Authenticate(this._userModel);
       
            if (CurrentUser.IsAuthenticated())
            {
                RedirectDecorator.ToViewModel(typeof(MenuViewModel));
            }
            else
            {
                 MessageError.InvalidIdentityForm.Show();
                _userModel = new UserModel();
            }
        }

        private void ShowSignUp()
        {
            Messenger.Default.Send(new ChangePage(typeof(SignUpViewModel)));
        }
        
    }
}