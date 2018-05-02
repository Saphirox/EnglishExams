using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Services
{
    public interface IQuestionService
    {
        void AddToTest(UserTestModel userTestModel, ICollection<QuestionModel> questionModel);

        UserTestModel GetTestByTaskDescription(TestDescription userTestModel);
    }
}