using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Services
{
    public interface ITestService
    {
        UserTestModel Add(UserTestModel userTestModel);

        UserTestModel GetTestByTaskDescription(TestKey key);

        UserTestModel GetTestByTaskDescriptionWithPermution(TestKey key);
    }
}