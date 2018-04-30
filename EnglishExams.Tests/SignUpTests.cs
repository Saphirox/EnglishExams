using EnglishExams.Infrastructure;
using EnglishExams.Models;
using Moq;
using NUnit.Framework;

namespace EnglishExams.Tests
{
    [TestFixture]
    public class SignUpTests
    {
        private string TestDirectory = TestContext.CurrentContext.TestDirectory.Replace("bin\\Debug", string.Empty);

        // SUT -> Service under test
        private IUserService _sut;

        [SetUp]
        public void SetUp()
        {
            var fileService = new FileFacade();
            fileService.CurrentDirectory = TestDirectory;
            
            _sut = new UserService(fileService);
        }

        [Test]
        public void AddUserModel()
        {
            var model = new UserModel
            {
                Password = "Password",
                UserName = "Name"
            };

            _sut.Add(model);
        }
    }
}