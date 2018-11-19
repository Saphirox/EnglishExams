using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;


namespace EnglishExams.ViewModels
{
    using KeyValue = KeyValuePair<string, IEnumerable<GradebookTestResultModel>>;
    public class GradebookViewModel : ViewModelBase
    {
        private readonly ITestService _testService;
        private readonly ITestResultService _resultService;

        public IEnumerable<KeyValue> Tests =>
            GetTestGradebookTestResults().Result;

        public RelayCommand ConcreteLesson { get; set; }

        public GradebookViewModel(ITestResultService resultService, ITestService testService)
        {
            _testService = testService;
            _resultService = resultService;
        }

        public void ShowConcreteLesson(TestKey key)
        {
            var test = _testService.GetTestByTaskDescription(key);
            RedirectDecorator.ToViewModel(ChangePage.CreateAndPassData(typeof(TestResultViewModel), typeof(UserTestModel), test)
        );
        }


        private async Task<IEnumerable<KeyValue>> GetTestGradebookTestResults()
        {
            var result = (await _resultService.GetGradebook())
                .GroupBy(c => c.UnitName, (s, models) => new KeyValue(s, models))
                .ToList();

            return new ObservableCollection<KeyValue>(result);
        }
    }
}