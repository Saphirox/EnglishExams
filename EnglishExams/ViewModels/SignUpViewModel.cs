using System.Windows.Input;
using EnglishExams.Infrastructure;
using EnglishExams.Models;

namespace EnglishExams.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private IUserService _userService => new UserService(new FileFacade());
        public RelayCommand ShowSignInPage { get; set; }

        public UserModel NewUser { get; set; } = new UserModel();

        public string Password
        {
            get => NewUser.Password;
            set
            {
                NewUser.Password = value;
                OnPropertyChanged(nameof(Password));
                //CommandManager.InvalidateRequerySuggested();
            }

        }

        public string UserName
        {
            get => NewUser.UserName;
            set
            {
                NewUser.UserName = value;
                OnPropertyChanged(nameof(UserName));
                //CommandManager.InvalidateRequerySuggested();
            }
        }

        public SignUpViewModel()
        {
            ShowSignInPage = new RelayCommand(ShowSignIn);
        }

        public bool Validate()
        {
            var result = true;

            var isEmpty = 
                string.IsNullOrWhiteSpace(UserName) || 
                string.IsNullOrWhiteSpace(Password);

            if (isEmpty)
                result = false;

            return result;
        }

        public void ShowSignIn()
        {
            if (Validate())
            {
                _userService.Add(NewUser);
                RedirectDecorator.ToViewModel(typeof(LoginViewModel));
            }
            else
            {
                MessageError.InvalidIdentityForm.Show();
            }
        }
    }
}