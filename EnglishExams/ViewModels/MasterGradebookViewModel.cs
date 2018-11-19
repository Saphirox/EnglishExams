using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;

namespace EnglishExams.ViewModels
{
    public class MasterGradebookViewModel : ViewModelBase
    {
        private ITestResultService _resultService;

        public IEnumerable<MasterGradebookTestResultModel> StudentsGradebooks { get; }

        public IEnumerable<TestKey> ColumnHeaders => 
            new ObservableCollection<TestKey>(
                    StudentsGradebooks.SelectMany(sg => sg.Results)
                                      .Select(c => c)
                                      .Distinct());

        public MasterGradebookViewModel(ITestResultService testResultService)
        {
            _resultService = testResultService;

            var gradebooks = _resultService.GetMasterGradebook();

            StudentsGradebooks = new ObservableCollection<MasterGradebookTestResultModel>(gradebooks);
        }
    }
}