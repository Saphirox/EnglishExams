
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using NUnit.Framework;

namespace EnglishExams.Tests
{
    [TestFixture]
    public class TestResultServiceTests
    {
        private ITestResultService _testResultService;

        public void GetResultTest()
        {
            var testDescription = new TestDescription ()
            {
                UnitName = "UnitТфьу"
            }

            _testResultService.GetResults()
        }
    }
}