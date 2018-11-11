using EnglishExams.Application.Infrastructure;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;
using EnglishExams.ViewModels;
using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using LittleSocialNetwork.DataAccess.EF.Implementation;
using System.Data.Entity;
using EnglishExams.Common;

namespace EnglishExams.Infrastructure
{
    internal class AppNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
            this.Bind<EnglishExamsDbContext>().ToSelf()
                .WithConstructorArgument("connectionString",
                    DbSettings.CONNECTION_STRING
                    );
            this.Bind<ITestService>().To<TestService>();
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
