using System;
using System.Collections.ObjectModel;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;

namespace EnglishExams.ViewModels
{
    public class TestListViewModel : ViewModelBase
    {
        public ObservableCollection<TestListModel> Tests { get; set; }

        public TestListViewModel(ITestListService testListService)
        {
            Tests = new ObservableCollection<TestListModel>(
                UserTestModel.ToTaskList(testListService.GetListByTeacher()));
            // TODO: FIX ME
            //RedirectDecorator.ToViewModel(typeof(MainWindowViewModel));
            //MessageError.TeacherNotFound.Show();
        }

        public void StartTest(TestKey test)
        {
            TinyTempCache.Set(typeof(TestKey), test);
            RedirectDecorator.ToViewModel(typeof(StartedTestViewModel));
        }
    }
}