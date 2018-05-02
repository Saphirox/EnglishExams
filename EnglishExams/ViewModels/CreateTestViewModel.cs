using EnglishExams.Infrastructure;
using EnglishExams.Models;

namespace EnglishExams.ViewModels
{
    public class CreateTestViewModel : ViewModelBase
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
                if (int.TryParse(value, out var result))
                {
                    _model.Duration = result;
                }
                else
                {
                    MessageError.FieldConsistOnlyDigits.Show();
                }

                OnPropertyChanged(nameof(Duration));
            }
        }

        public string NumberOfQuestions
        {
            get => _model.NumberOfQuestions.ToString();
            set
            {
                if (int.TryParse(value, out var result))
                {
                    _model.NumberOfQuestions = result;
                }
                else
                {
                    MessageError.FieldConsistOnlyDigits.Show();
                }

                OnPropertyChanged(nameof(NumberOfQuestions));
            }
        }

        public string NumberOfPoints
        {
            get => _model.NumberOfPoints.ToString();
            set
            {
                if (int.TryParse(value, out var result))
                {
                    _model.NumberOfPoints = result;
                }
                else
                {
                    MessageError.FieldConsistOnlyDigits.Show();
                }

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
            TinyTempCache.Set(typeof(UserTestModel), _model);
            RedirectDecorator.ToViewModel(typeof(QuestionViewModel));
        }
    }
}