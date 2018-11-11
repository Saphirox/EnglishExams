using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Services
{
    public interface IQuestionService
    {
        void AddToTest(UserTestModel userTestModel);

        UserTestModel GetTestByTaskDescription(TestKey key);

        UserTestModel GetTestByTaskDescriptionWithPermution(TestKey key);
    }
}