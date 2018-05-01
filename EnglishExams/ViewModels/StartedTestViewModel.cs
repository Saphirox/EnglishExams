﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using System.Windows.Threading;
using EnglishExams.Resources;

namespace EnglishExams.ViewModels
{
    public class StartedTestViewModel : ViewModelBase
    {
        private TestDescription _testDescription;
        private DispatcherTimer dispatcherTimer;
        private IQuestionService _questionService;
        private Dictionary<string, ICollection<string>> _answers;
        private readonly UserTestModel _userTestModel;
        private int _pointer = 0; 
        private int _timer = 0;

        public RelayCommand NextQuestion { get; set; }
        public RelayCommand TestResult { get; set; }
        public int Timer
        {
            get => _timer;
            set
            {
                _timer = value;
                OnPropertyChanged(nameof(Timer));
                OnPropertyChanged(nameof(TestDuration));
            }
        }

        private QuestionModel GetQuestionByIndex()
        {
            return _userTestModel.QuestionModels.ElementAt(_pointer);
        }

        public string Header => 
            string.Concat(_userTestModel.UnitName, " - ", _userTestModel.LessonName);

        public string TestDuration
            => string.Concat(CommonResources.Duration, " ", new TimeSpan(0, 0, Timer).ToString("g"));

        public string QuestionNumber => 
            string.Concat(CommonResources.Question, " ", (_pointer + 1).ToString(), 
                "/", _userTestModel.NumberOfQuestions);

        public string QuestionName => GetQuestionByIndex().Text;

        public IEnumerable<OptionModel> CurrentOptions
                    => new ObservableCollection<OptionModel>(GetQuestionByIndex().Options.Where(c => c.Name != null));

        public StartedTestViewModel()
        {
            _answers = new Dictionary<string, ICollection<string>>();
            _testDescription = TinyCache.Get<Type, TestDescription>(typeof(TestDescription));
            _questionService = new QuestionService(new FileFacade());

            _userTestModel = _questionService.GetTestByTaskDescription(_testDescription);

            NextQuestion = new RelayCommand(ShowNextQuestion);
            TestResult = new RelayCommand(ShowTestResult);

            StartTimer();
        }

        public void AddAnswer(string questionText, string answer)
        {
            if (_answers.ContainsKey(questionText))
            {
                _answers[questionText].Add(answer);
            }
            else
            {
                _answers.Add(questionText, new List<string> { answer });
            }
        }

        public void RemoveAnswer(string questionText, string answer)
        {
            _answers[questionText].Remove(answer);
        }

        private void ShowNextQuestion()
        {
            if (_pointer > _userTestModel.Duration)
            {
                _pointer = 0;
            }
            else
            {
                _pointer++;
            }

            OnPropertyChanged(nameof(QuestionName));
            OnPropertyChanged(nameof(CurrentOptions));
        }

        private void ShowTestResult()
        {
            // TODO: Add result page
        }

        private void StartTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 1)};
            dispatcherTimer.Tick += (obj, e) => Timer++;
            dispatcherTimer.Start();
        }
    }
}