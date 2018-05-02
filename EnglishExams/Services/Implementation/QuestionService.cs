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
        private readonly IFileWrapper _fileWrapper;
        private readonly IUserService _userService;

        public QuestionService(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
            _userService = new UserService(_fileWrapper);
        }

        public void AddToTest(UserTestModel userTestModel, ICollection<QuestionModel> questionModel)
        {
            userTestModel.QuestionModels = questionModel;

            CurrentUser.Instance.UserTestModels.Add(userTestModel);

            _userService.Update(CurrentUser.Instance);
        }

        public UserTestModel GetTestByTaskDescription(TestDescription userTestModel)
        {
            var test = CurrentUser.Instance.UserTestModels.FirstOrDefault(
                c => c.LessonName == userTestModel.LessonName &&
                     c.UnitName == userTestModel.UnitName);

            return test;
        }
    }
}