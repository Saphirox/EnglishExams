using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;

namespace EnglishExams.ViewModels
{
    using KeyValue = KeyValuePair<string, IEnumerable<GradebookTestResultModel>>;

    public class MasterGradebookViewModel
    {

        public IEnumerable<KeyValue> Tests { get; set; }
        private ITestResultService _resultService;
        private readonly IQuestionService _questionService;
        private IFileWrapper _fileWrapper;

        public MasterGradebookViewModel()
        {
            _fileWrapper = new FileWrapper();

            _resultService = new TestResultService(_fileWrapper);


            var result = _resultService.GetGradebook();

            var dict = result.GroupBy(c => c.Key.UnitName, (s, models) => new KeyValue(s, models));

            Tests = new ObservableCollection<KeyValue>(dict);

            _questionService = new QuestionService(_fileWrapper);
        }
    }
}