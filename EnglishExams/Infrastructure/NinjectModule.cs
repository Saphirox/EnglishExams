using EnglishExams.Services;
using EnglishExams.Services.Implementation;
using EnglishExams.ViewModels;
using Ninject;
using Ninject.Modules;

namespace EnglishExams.Infrastructure
{
    public class AppNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFileWrapper, FileWrapper>();
            this.Bind<IQuestionService, QuestionService>();
            this.Bind<ITestListService, TestListService>();
            this.Bind<ITestResultService, TestResultService>();
            this.Bind<IUserService, UserService>();
            this.Bind<GradebookViewModel>();
        }
    }

    public static class NinjectFactory
    {
        private static IKernel _instance;

        public static IKernel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new StandardKernel(new AppNinjectModule());
            }

            return _instance;
        }
    }
}
