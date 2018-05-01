using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Infrastructure
{
    public interface IQuestionService
    {
        void AddToTest(UserTestModel userTestModel, ICollection<QuestionModel> questionModel);
    }
}