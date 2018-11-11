using EnglishExams.Infrastructure;
using EnglishExams.Services;
using EnglishExams.Services.Implementation;
using EnglishExams.ViewModels;
using NUnit.Framework;
using Shouldly;

namespace EnglishExams.Tests.Infrastructure
{
    [TestFixture]
    public class NinjectTests
    {
        [Test]
        public void AllServicesProperlyInjected()
        {
            var instance = NinjectFactory.GetInstance();

            instance.GetService(typeof(IQuestionService)).ShouldNotBeNull();
            instance.GetService(typeof(IQuestionService)).ShouldBeOfType<QuestionService>();

            instance.GetService(typeof(ITestListService)).ShouldNotBeNull();
            instance.GetService(typeof(ITestListService)).ShouldBeOfType<TestListService>();

            instance.GetService(typeof(ITestResultService)).ShouldNotBeNull();
            instance.GetService(typeof(ITestResultService)).ShouldBeOfType<TestResultService>();

            instance.GetService(typeof(IUserService)).ShouldNotBeNull();
            instance.GetService(typeof(IUserService)).ShouldBeOfType<UserService>();

            instance.GetService(typeof(BackButtonViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(CreateTestViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(GradebookViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(LoginViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(BackButtonViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(MainWindowViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(MasterGradebookViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(MenuViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(QuestionViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(SignUpViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(StartedTestViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(TestListViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(TestResultViewModel)).ShouldNotBeNull();
            instance.GetService(typeof(ViewModelBase)).ShouldNotBeNull();
        }
    }
}
