using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Resources;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;

namespace EnglishExams.ViewModels
{
    public class TestResultViewModel : ViewModelBase
    {
        private readonly UserTestModel _userTestModel;
        private ITestResultService _testResultService;
        private readonly ICollection<TestResultDescriptionModel> _testResults;
        private const string DASH = " - ";
        
        public string Header =>
            string.Concat(_userTestModel.UnitName, DASH, 
                          _userTestModel.LessonName, CommonResources.Analysis);

        public ICollection<TestResultDescriptionModel> TestResult
            => new ObservableCollection<TestResultDescriptionModel>(_testResults);

        public TestResultViewModel()
        {
            _testResultService = new TestResultService(new FileWrapper());

            _userTestModel = TinyTempCache.Get<Type, UserTestModel>(typeof(UserTestModel));

            _testResults = _testResultService.GetResults(new TestDescription
            {
                UnitName = _userTestModel.UnitName,
                LessonName = _userTestModel.LessonName
            });
        }
    }
}