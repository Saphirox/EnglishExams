using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EnglishExams.Infrastructure;
using EnglishExams.Models;

namespace EnglishExams.ViewModels
{
    public class GradebookViewModel : ViewModelBase
    {
        public ObservableCollection<GradebookTestResultModel> Tests { get; set; }
        public IList<GradebookTestResultModel> GradebookModels { get; set; }
        private ITestResultService _resultService;
        private readonly IQuestionService _questionService;
        private IFileFacade _fileFacade;
        public RelayCommand ConcreteLesson { get; set; }

        public GradebookViewModel()
        {
            _fileFacade = new FileFacade();

            _resultService =  new TestResultService(_fileFacade);

            Tests = new ObservableCollection<GradebookTestResultModel>(
                _resultService.GetGradebook());

            _questionService = new QuestionService(_fileFacade);
        }

        public void ShowConcreteLesson(TestDescription description)
        {
            var test = _questionService.GetTestByTaskDescription(description);

            TinyCache.Set(typeof(UserTestModel), test);
            RedirectDecorator.ToViewModel(typeof(TestResultViewModel));
        } 
    }
}