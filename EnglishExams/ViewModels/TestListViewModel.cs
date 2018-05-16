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
        private ITestListService _testListService;
        private readonly IUserService _userService;
        private readonly IFileWrapper _fileWrapper;

        public ObservableCollection<TestListModel> Tests { get; set; }

        public TestListViewModel()
        {
            _fileWrapper = new FileWrapper();
            _userService = new UserService(_fileWrapper);
            _testListService = new TestListService(_userService);

            var teacherList = _testListService.GetListByTeacher();
            Tests = new ObservableCollection<TestListModel>(teacherList.ToTaskList());
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