using System;
using System.Collections.Generic;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Resources;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;
using GalaSoft.MvvmLight.Messaging;

namespace EnglishExams.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        private int _count = 1;
        private const int MAX_QUESTIONS = 12;

        private readonly IQuestionService _questionService;

        private QuestionModel _model = new QuestionModel {
            Options = new List<OptionModel>()
        };

        private readonly List<QuestionModel> _questionModels = new List<QuestionModel>();
        private readonly UserTestModel _userTestModel;

        public RelayCommand NextQuestion { get; set; }
        public RelayCommand ReturnToMenu { get; set; }
        public RelayCommand EndQuestions { get; set; }

        private OptionModel option1 = new OptionModel();
        private OptionModel option2 = new OptionModel();
        private OptionModel option3 = new OptionModel();
        private OptionModel option4 = new OptionModel();
        private OptionModel option5 = new OptionModel();
        
        public string QuestionNumber 
            => string.Concat(CommonResources.Question, " ", _count.ToString());

        public string Text
        {
            get => _model.Text;
            set
            {
                _model.Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public string Option1
        {
            get => option1.Name;
            set
            {
                option1.Name = value;
                OnPropertyChanged(nameof(Option1));
            }
        }

        public string Option2
        {
            get => option2.Name;
            set
            {
                option2.Name = value;
                OnPropertyChanged(nameof(Option2));
            }
        }

        public string Option3
        {
            get => option3.Name;
            set
            {
                option3.Name = value;
                OnPropertyChanged(nameof(Option3));
            }
        }

        public string Option4
        {
            get => option4.Name;
            set
            {
                option4.Name = value;
                OnPropertyChanged(nameof(Option4));
            }
        }

        public string Option5
        {
            get => option5.Name;
            set
            {
                option5.Name = value;
                OnPropertyChanged(nameof(Option5));
            }
        }

        public bool Option1Checked
        {
            get => option1.IsCorrect;
            set
            {
                option1.IsCorrect = value;
                OnPropertyChanged(nameof(Option1Checked));
            }
        }

        public bool Option2Checked
        {
            get => option2.IsCorrect;
            set
            {
                option2.IsCorrect = value;
                OnPropertyChanged(nameof(Option2Checked));
            }
        }

        public bool Option3Checked
        {
            get => option3.IsCorrect;
            set
            {
                option3.IsCorrect = value;
                OnPropertyChanged(nameof(Option3Checked));
            }
        }

        public bool Option4Checked
        {
            get => option4.IsCorrect;
            set
            {
                option4.IsCorrect = value;
                OnPropertyChanged(nameof(Option4Checked));
            }
        }

        public bool Option5Checked
        {
            get => option5.IsCorrect;
            set
            {
                option5.IsCorrect = value;
                OnPropertyChanged(nameof(Option5Checked));
            }
        }

        public QuestionViewModel()
        {
            _questionService = new QuestionService(new FileWrapper());
            _userTestModel = TinyTempCache.Get<Type, UserTestModel>(typeof(UserTestModel));

            NextQuestion = new RelayCommand(ShowNextQuestion);
            ReturnToMenu = new RelayCommand(ShowMenu);
            EndQuestions = new RelayCommand(AddTestToUser);
        }

        private void AddTestToUser()
        {
            _questionService.AddToTest(_userTestModel, _questionModels);

            RedirectDecorator.ToViewModel(typeof(MenuViewModel));
        }

        private void ShowNextQuestion()
        {
            _model.Options.Add(option1);
            _model.Options.Add(option2);
            _model.Options.Add(option3);
            _model.Options.Add(option4);
            _model.Options.Add(option5);

            _questionModels.Add(_model);

            ClearModel();

            _count++;
            OnPropertyChanged(nameof(QuestionNumber));
        }

        private void ShowMenu()
        {
            RedirectDecorator.ToViewModel(typeof(MenuViewModel));
        }

        private void ClearModel()
        {
            _model = new QuestionModel();
            _model.Options = new List<OptionModel>();

            option1 = new OptionModel();
            option2 = new OptionModel();
            option3 = new OptionModel();
            option4 = new OptionModel();
            option5 = new OptionModel();
            option5 = new OptionModel();

            Text = "";
            Option1 = "";
            Option2 = "";
            Option3 = "";
            Option4 = "";
            Option5 = "";

            Option1Checked = false;
            Option2Checked = false;
            Option3Checked = false;
            Option4Checked = false;
            Option5Checked = false;
        }
    }
}