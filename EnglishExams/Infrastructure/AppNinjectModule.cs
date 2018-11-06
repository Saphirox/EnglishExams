using EnglishExams.Services;
using EnglishExams.Services.Implementation;
using EnglishExams.ViewModels;
using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace EnglishExams.Infrastructure
{
    public class AppNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFileWrapper>().To<FileWrapper>();
            this.Bind<IQuestionService>().To<QuestionService>();
            this.Bind<ITestListService>().To<TestListService>();
            this.Bind<ITestResultService>().To<TestResultService>();
            this.Bind<IUserService>().To<UserService>();

            this.Bind(x => x
                .FromThisAssembly()
                .SelectAllClasses()
                .InheritedFrom<ViewModelBase>()
                .BindBase()
                .Configure(c => c.InTransientScope()));
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
