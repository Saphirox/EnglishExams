//using EnglishExams.Application.Infrastructure;
//using EnglishExams.Infrastructure;
//using EnglishExams.Models;
//using EnglishExams.Services;
//using EnglishExams.Services.Implementation;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EnglishExams.Tests.Services
//{
//    [TestFixture]
//    public class QuestionServiceTests
//    {
//        private IQuestionService _questionService;
//        private Mock<IUnitOfWork> _uowMock;

//        public QuestionServiceTests()
//        {
//            _questionService = new QuestionService(_uowMock.Object);
//        }

//        [Test]
//        public void AddTest_throws_exception_if_param_is_null()
//        {
//            Assert.Throws<ArgumentNullException>(() => _questionService.AddToTest(null));
//        }

//        [Test]
//        public void AddTest_add_test()
//        {
//        }
//    }
//}
