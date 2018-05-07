using System;
using System.Collections.Generic;
using System.Linq;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Resources;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;
using GalaSoft.MvvmLight.Messaging;

namespace EnglishExams.ViewModels
{
    public class QuestionViewModel : ViewModelBase, IViewModelValidation
    {
        private int _countOfQuestion = 1;

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
            => string.Concat(CommonResources.Question, " ", _countOfQuestion.ToString());

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

                if (string.IsNullOrWhiteSpace(option1.Name))
                {
                    Option1Checked = false;
                }

                OnPropertyChanged(nameof(Option1));
            }
        }

        public string Option2
        {
            get => option2.Name;
            set
            {
                option2.Name = value;

                if (string.IsNullOrWhiteSpace(option2.Name))
                {
                    Option2Checked = false;
                }
                OnPropertyChanged(nameof(Option2));
            }
        }

        public string Option3
        {
            get => option3.Name;
            set
            {
                option3.Name = value;

                if (string.IsNullOrWhiteSpace(option3.Name))
                {
                    Option3Checked = false;
                }

                OnPropertyChanged(nameof(Option3));
            }
        }

        public string Option4
        {
            get => option4.Name;
            set
            {
                option4.Name = value;

                if (string.IsNullOrWhiteSpace(option4.Name))
                {
                    Option4Checked = false;
                }

                OnPropertyChanged(nameof(Option4));
            }
        }

        public string Option5
        {
            get => option5.Name;
            set
            {
                option5.Name = value;

                if (string.IsNullOrWhiteSpace(option5.Name))
                {
                    Option5Checked = false;
                }

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

            NextQuestion = new RelayCommand(AddClearModel);
            ReturnToMenu = new RelayCommand(ShowMenu);
        }

        private void AddTestToUser()
        {
            _questionService.AddToTest(_userTestModel, _questionModels);

            RedirectDecorator.ToViewModel(typeof(MenuViewModel));
        }

        private void AddClearModel()
        {
            if (!Validate())
            {
                return;
            }
         
            _model.Options.Add(option1);
            _model.Options.Add(option2);
            _model.Options.Add(option3);
            _model.Options.Add(option4);
            _model.Options.Add(option5);

            _model.Options = _model.Options.Where(value => 
                !string.IsNullOrWhiteSpace(value.Name)).ToList();

            _questionModels.Add(_model);

            ClearModel();

            if (_userTestModel.NumberOfQuestions == _countOfQuestion)
            {
                AddTestToUser();
                return;
            }

            _countOfQuestion++;

            OnPropertyChanged(nameof(QuestionNumber));
        }

        public bool Validate()
        {
            var state = true;

            // Option 1 and 2 is required
            if (string.IsNullOrWhiteSpace(Option1) || string.IsNullOrWhiteSpace(Option2))
            {
                state = false;
                MessageError.FirstAndSecondOptionIsRequired.Show();
            }
            else if (string.IsNullOrWhiteSpace(_model.Text))
            {
                state = false;
                MessageError.AllFieldsIsRequired.Show();
            }

            return state;
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

            Text = null;
            Option1 = null;
            Option2 = null;
            Option3 = null;
            Option4 = null;
            Option5 = null;

            Option1Checked = false;
            Option2Checked = false;
            Option3Checked = false;
            Option4Checked = false;
            Option5Checked = false;
        }
    }
}