﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using System.Windows.Threading;
using EnglishExams.Resources;
using EnglishExams.Services;

namespace EnglishExams.ViewModels
{
    public class StartedTestViewModel : ViewModelBase
    {
        private TestKey _testKey;
        private ITestService _testService;
        private DispatcherTimer _dispatcherTimer;
        private readonly ITestResultService _testResultService;
        private readonly Dictionary<string, ICollection<string>> _answers;
        private readonly UserTestModel _userTestModel;
        private int _pointer = 0;
        private int _timer = 0;

        public StartedTestViewModel(ITestService testService, ITestResultService testResultService)
        {
            _answers = new Dictionary<string, ICollection<string>>();

            _testKey = TinyTempCache.Get<Type, TestKey>(typeof(TestKey));
            _testService = testService;
            _testResultService = testResultService;
            _userTestModel = _testService.GetTestByTaskDescriptionWithPermution(_testKey);

            _timer = _userTestModel.Duration;

            NextQuestion = new RelayCommand(ShowNextQuestion);
            TestResult = new RelayCommand(ShowTestResult);
            Back = new RelayCommand(ShowBack);

            Reset();
            StartTimer();
        }

        public RelayCommand NextQuestion { get; set; }
        public RelayCommand TestResult { get; set; }
        public RelayCommand Back { get; set; }

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

        public IList<OptionModel> CurrentOptions { get; set; }

        public void ShowBack()
        {
            AddAnswer();

            if (_pointer == 0)
            {
                _pointer = _userTestModel.NumberOfQuestions - 1;
            }
            else
            {
                _pointer--;
            }

            RestoreCheckedCheckboxes();
            OnPropertyChanged(nameof(QuestionName));
            OnPropertyChanged(nameof(CurrentOptions));
            OnPropertyChanged(nameof(QuestionNumber));
        }

        public void AddAnswer()
        {
            var correctAnswers = CurrentOptions.Where(c => c.IsCorrect);

            if (_answers.ContainsKey(QuestionName))
            {
                _answers[QuestionName].Clear();

                foreach (var result in correctAnswers)
                {
                    _answers[QuestionName].Add(result.Name);
                }
            }
            else
            {
                _answers.Add(QuestionName, correctAnswers.Select(c => c.Name).ToList());
            }
        }

        private void ShowNextQuestion()
        {
            AddAnswer();

            if (_pointer >= _userTestModel.NumberOfQuestions - 1)
            {
                _pointer = 0;
            }
            else
            {
                _pointer++;
            }

            RestoreCheckedCheckboxes();

            OnPropertyChanged(nameof(QuestionName));
            OnPropertyChanged(nameof(CurrentOptions));
            OnPropertyChanged(nameof(QuestionNumber));
        }

        private void ShowTestResult()
        {
            Redirect();
        }

        private void Redirect()
        {
            foreach (var emptyQuestion in _userTestModel.QuestionModels.Where(c => !_answers.Keys.Contains(c.Text)))
            {
                 _answers.Add(emptyQuestion.Text, emptyQuestion.Options.Select(c => c.Name).ToList());
            }

            _testResultService.AddResultToUser(new TestKey
            {
                UnitName = _userTestModel.UnitName,
                LessonName = _userTestModel.LessonName
            }, _answers);

            TinyTempCache.Set(typeof(UserTestModel), _userTestModel);
            _dispatcherTimer.Stop();

            RedirectDecorator.ToViewModel(typeof(TestResultViewModel));
        }

        private void StartTimer()
        {
            _dispatcherTimer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 1)};

            _dispatcherTimer.Tick += (obj, e) =>
            {
                Timer--;

                if (Timer == 0)
                {
                    MessageError.TimeOfTestExpired.Show();
                    Redirect();
                }
            };

            _dispatcherTimer.Start();
        }

        private void RestoreCheckedCheckboxes()
        {
           Reset();
           Set();
        }

        private void Set()
        {
            foreach (var option in CurrentOptions)
            {
                foreach (var answer in _answers)
                {
                    if (answer.Key == QuestionName && 
                        answer.Value.Contains(option.Name))
                    {
                        option.IsCorrect = true;
                    }
                }
            }
        }

        private void Reset()
        {
            CurrentOptions = new ObservableCollection<OptionModel>(GetQuestionByIndex().Options.Select(c =>
                new OptionModel
                {
                    Name = c.Name,
                    IsCorrect = false
                }));
        }
    }
}