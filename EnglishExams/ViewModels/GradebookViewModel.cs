using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;

namespace EnglishExams.ViewModels
{
    public class GradebookViewModel : ViewModelBase
    {
        public ObservableCollection<GradebookTestResultModel> Tests { get; set; }
        public IList<GradebookTestResultModel> GradebookModels { get; set; }
        private ITestResultService _resultService;
        private readonly IQuestionService _questionService;
        private IFileWrapper _fileWrapper;
        public RelayCommand ConcreteLesson { get; set; }

        public GradebookViewModel()
        {
            _fileWrapper = new FileWrapper();

            _resultService =  new TestResultService(_fileWrapper);

            Tests = new ObservableCollection<GradebookTestResultModel>(
                _resultService.GetGradebook());

            _questionService = new QuestionService(_fileWrapper);
        }

        public void ShowConcreteLesson(TestDescription description)
        {
            var test = _questionService.GetTestByTaskDescription(description);

            TinyTempCache.Set(typeof(UserTestModel), test);
            RedirectDecorator.ToViewModel(typeof(TestResultViewModel));
        } 
    }
}