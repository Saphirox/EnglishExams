using System.Collections.ObjectModel;
using EnglishExams.Infrastructure;
using EnglishExams.Models;

namespace EnglishExams.ViewModels
{
    public class TestListViewModel : ViewModelBase
    {
        public ObservableCollection<TaskListModel> Tests { get; set; }

        public TestListViewModel()
        {
            Tests = new ObservableCollection<TaskListModel>(
                    CurrentUser.Instance.UserTestModels.ToTaskList());
        }

        public void StartTest(TestDescription test)
        {
            TinyCache.Set(typeof(TestDescription), test);
            RedirectDecorator.ToViewModel(typeof(RunnedTest));
        }
    }
}