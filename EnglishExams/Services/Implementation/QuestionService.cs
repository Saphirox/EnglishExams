using System.Collections.Generic;
using System.Linq;
using EnglishExams.Infrastructure;
using EnglishExams.Models;

namespace EnglishExams.Services.Implementation
{
    /// <summary>
    /// Perform action on QuestionModels
    /// </summary>
    public class QuestionService : IQuestionService
    {
        private readonly IUserService _userService;

        public QuestionService(IFileWrapper fileWrapper)
        {
            _userService = new UserService(fileWrapper);
        }

        public void AddToTest(UserTestModel userTestModel, ICollection<QuestionModel> questionModel)
        {
            userTestModel.QuestionModels = questionModel;

            CurrentUser.Instance.UserTestModels.Add(userTestModel);

            _userService.Update(CurrentUser.Instance);
        }

        public UserTestModel GetTestByTaskDescription(TestKey key)
        {
            var test = CurrentUser.Instance.UserTestModels.FirstOrDefault(c => c.Key == key);

            return test;
        }
    }
}