using System.Collections.Generic;
using System.Linq;
using EnglishExams.Common;
using EnglishExams.Models;

namespace EnglishExams.Infrastructure
{
    public class QuestionService : IQuestionService
    {
        private readonly IFileFacade _fileFacade;
        private readonly IUserService _userService;

        public QuestionService(IFileFacade fileFacade)
        {
            _fileFacade = fileFacade;
            _userService = new UserService(_fileFacade);
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