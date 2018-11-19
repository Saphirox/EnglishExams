using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Resources;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;

namespace EnglishExams.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private IUserService _userService;
        public RelayCommand ShowSignInPage { get; set; }

        public UserModel NewUser { get; set; } = new UserModel();

        public SignUpViewModel(IUserService userService)
        {
            _userService = userService;
            ShowSignInPage = new RelayCommand(ShowSignIn);
        }


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
            }
        }

        public bool IsMaster
        {
            get => NewUser.Role != default;
            set
            {
                NewUser.Role = value ? Roles.Master : Roles.Student;
                OnPropertyChanged(nameof(IsMaster));
            }
        }

        public bool Validate()
        {
            var result = true;

            var isEmpty = 
                string.IsNullOrWhiteSpace(UserName) || 
                string.IsNullOrWhiteSpace(Password);

            if (isEmpty)
                result = false;

            if (_userService.IsTeacher(UserName, Password))
            {
                MessageError.Show(ErrorResources.TeacherAlreadyExist);
                result = false;
            }

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