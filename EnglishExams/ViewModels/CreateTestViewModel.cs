using EnglishExams.Infrastructure;
using EnglishExams.Models;

namespace EnglishExams.ViewModels
{
    public class CreateTestViewModel : ViewModelBase, IViewModelValidation
    {
        public RelayCommand BackPage { get; set; }
        public RelayCommand BeginPage { get; set; }

        private readonly UserTestModel _model = new UserTestModel();

        public string UnitName
        {
            get => _model.UnitName;
            set
            {
                _model.UnitName = value;
                OnPropertyChanged(nameof(UnitName));
            }
        }

        public string LessonName
        {
            get => _model.LessonName;
            set
            {
                _model.LessonName = value;
                OnPropertyChanged(nameof(LessonName));
            }
        }

        public string Duration
        {
            get => _model.Duration.ToString();
            set
            {
                _model.Duration = value.ValidateNumber();

                OnPropertyChanged(nameof(Duration));
            }
        }

        public string NumberOfQuestions
        {
            get => _model.NumberOfQuestions.ToString();
            set
            {
                _model.NumberOfQuestions = value.ValidateNumber();

                OnPropertyChanged(nameof(NumberOfQuestions));
            }
        }

        public string NumberOfPoints
        {
            get => _model.NumberOfPoints.ToString();
            set
            {
                _model.NumberOfPoints = value.ValidateNumber();

                OnPropertyChanged(nameof(NumberOfPoints));
            }
        }

        public CreateTestViewModel()
        {
            BackPage = new RelayCommand(ShowBack);
            BeginPage = new RelayCommand(ShowBegin);
        }

        private void ShowBack()
        {
            RedirectDecorator.ToViewModel(typeof(MenuViewModel));
        }

        private void ShowBegin()
        {
            if (!Validate())
            {
                return;
            }

            TinyTempCache.Set(typeof(UserTestModel), _model);
            RedirectDecorator.ToViewModel(typeof(QuestionViewModel));
        }

        public bool Validate()
        {
            var result = true;

            if (string.IsNullOrWhiteSpace(UnitName) || 
                string.IsNullOrWhiteSpace(LessonName) ||
                int.Parse(Duration) == default ||
                int.Parse(NumberOfQuestions) == default || 
                int.Parse(NumberOfPoints) == default)
            {
                result = false;
                MessageError.AllFieldsIsRequired.Show();
            }

            return result;
        }
    }
}