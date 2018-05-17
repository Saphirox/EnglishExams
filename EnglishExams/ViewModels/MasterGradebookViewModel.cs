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
        private IFileWrapper _fileWrapper;

        public IEnumerable<MasterGradebookTestResultModel> StudentsGradebooks { get; }

        public IEnumerable<TestKey> ColumnHeaders => 
            new ObservableCollection<TestKey>(
                    StudentsGradebooks.SelectMany(sg => sg.Results)
                                      .Select(c => c.Key)
                                      .Distinct());

        public MasterGradebookViewModel()
        {
            _fileWrapper = new FileWrapper();

            _resultService = new TestResultService(_fileWrapper);

            var gradebooks = _resultService.GetMasterGradebook();

            StudentsGradebooks = new ObservableCollection<MasterGradebookTestResultModel>(gradebooks);
        }
    }
}