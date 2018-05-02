using System.Collections.Generic;
using System.Linq;
using EnglishExams.Models;
using EnglishExams.Resources;

namespace EnglishExams.Infrastructure
{
    public class TestResultService : ITestResultService
    {
        private readonly IFileFacade _fileFacade;
        private readonly IUserService _userService;

        public TestResultService(IFileFacade fileFacade)
        {
            _fileFacade = fileFacade;
            _userService = new UserService(_fileFacade);
        }

        // TODO: Check me
        public void AddResultToUser(TestDescription key, Dictionary<string, ICollection<string>> answers)
        {
            var testResult = new TestResultModel
            {
                UnitName = key.UnitName,
                LessonName = key.LessonName,
                QuestionResultModels = answers.Select(c => new QuestionResultModel
                {
                    Text = c.Key,
                    OptionsName = c.Value
                }).ToList()
            };

            CurrentUser.Instance.TestResults.Add(testResult);

            _userService.Update(CurrentUser.Instance);
        }

        public IList<TestResultDescriptionModel> GetResults(TestDescription key)
        {
            var testResult = CurrentUser.Instance.TestResults.FirstOrDefault(
                c => c.UnitName == key.UnitName &&
                c.LessonName == key.LessonName);

            var test = CurrentUser.Instance.UserTestModels.FirstOrDefault(
                c => c.UnitName == key.UnitName &&
                     c.LessonName == key.LessonName);
            
            var list = new List<TestResultDescriptionModel>();
            var index = 0;
            foreach (var m in test.QuestionModels)
            {
                foreach (var q in testResult.QuestionResultModels)
                {
                    if (q.Text == m.Text)
                    {
                        var correctAnswers = m.Options.Where(c => c.IsCorrect).Select(c => c.Name);

                        var firstNotSecond = correctAnswers.Except(q.OptionsName).ToList();
                        var secondNotFirst = q.OptionsName.Except(correctAnswers).ToList();
                        
                        var result = !firstNotSecond.Any() && !secondNotFirst.Any();

                        ++index;

                        var points = test.NumberOfPoints / test.NumberOfQuestions * correctAnswers.Count();

                        var pointResult = (result ? points : 0).ToString();

                        list.Add(new TestResultDescriptionModel
                        {
                            QuestionNumber = string.Concat(CommonResources.Question, " ", index.ToString(),
                                "/", test.NumberOfQuestions.ToString()),
                            IsCorrect = result,
                            QuestionName = m.Text,
                            CorrectResult = string.Join(", ", correctAnswers),
                            QuestionPoints = string.Format(CommonResources.YouGotPattern, pointResult, 
                                test.NumberOfQuestions),
                            UserResult = string.Join(", ", q.OptionsName)
                        });
                    }
                }
            }

            return list;
        }
    }
}