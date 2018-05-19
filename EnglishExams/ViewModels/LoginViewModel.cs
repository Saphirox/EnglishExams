using System;
using System.IO;
using System.Windows.Forms;
using EnglishExams.Common;
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

        public RelayCommand Import { get; set; }

        public RelayCommand Export { get; set; }

        public LoginViewModel()
        {
            ShowSignUpPage = new RelayCommand(ShowSignUp);
            ShowMenuPage = new RelayCommand(ShowMenu);
            Import = new RelayCommand(ImportPersonalFile);
            Export = new RelayCommand(ExportPersonalFile);
        }

        private void ImportPersonalFile()
        {
            var dialog = new OpenFileDialog();

            string pathToFile = null;

            dialog.Title = "Open JSON File";
            dialog.Filter = "JSON files|*.json";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathToFile = dialog.FileName;
            }

            if (File.Exists(pathToFile))
            {
                if (File.Exists(FileConstants.PERSONAL_DATA_PATH))
                {
                    File.Delete(FileConstants.PERSONAL_DATA_PATH);
                    File.Copy(pathToFile, FileConstants.PERSONAL_DATA_PATH);
                }
            }
        }

        private void ExportPersonalFile()
        {
            var dialog = new SaveFileDialog();

            dialog.Title = "Open JSON File";
            dialog.Filter = "JSON files|*.json";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var pathToFile = dialog.FileName;

                File.Copy(FileConstants.PERSONAL_DATA_PATH, pathToFile);
            }
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