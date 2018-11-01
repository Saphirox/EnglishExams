using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;


namespace EnglishExams.ViewModels
{
    using KeyValue = KeyValuePair<string, IEnumerable<GradebookTestResultModel>>;
    public class GradebookViewModel : ViewModelBase
    {
        private readonly IQuestionService _questionService;
        private readonly ITestResultService _resultService;

        public IEnumerable<KeyValue> Tests => GetTestGradebookTestResults();

        public RelayCommand ConcreteLesson { get; set; }

        public GradebookViewModel(ITestResultService resultService, IQuestionService questionService)
        {
            _questionService = questionService;
            _resultService = resultService;
        }

        public void ShowConcreteLesson(TestKey key)
        {
            var test = _questionService.GetTestByTaskDescription(key);
            RedirectDecorator.ToViewModel(
                ChangePage.CreateAndPassDataWithTypeKey(typeof(TestResultViewModel), test));
        }

        private IEnumerable<KeyValue> GetTestGradebookTestResults()
        {
            return new ObservableCollection<KeyValue>(_resultService.GetGradebook()
                .GroupBy(c => c.Key.UnitName, (s, models) => new KeyValue(s, models)));
        }
    }
}