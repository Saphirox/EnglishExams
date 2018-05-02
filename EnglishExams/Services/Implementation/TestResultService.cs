using System.Collections.Generic;
using System.Linq;
using EnglishExams.Models;
using EnglishExams.Resources;

namespace EnglishExams.Infrastructure
{
    public class TestResultService : ITestResultService
    {
        private readonly IFileWrapper _fileWrapper;
        private readonly IUserService _userService;

        public TestResultService(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
            _userService = new UserService(_fileWrapper);
        }

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

            var existed = CurrentUser.Instance.TestResults.FirstOrDefault(
                c => c.LessonName == key.LessonName &&
                     c.UnitName == key.UnitName);

            if (existed != null)
            {
                CurrentUser.Instance.TestResults.Remove(existed);
            }

            CurrentUser.Instance.TestResults.Add(testResult);

            _userService.Update(CurrentUser.Instance);
        }

        public IList<GradebookTestResultModel> GetGradebook()
        {
            var testResults = CurrentUser.Instance.TestResults;
            var tests = CurrentUser.Instance.UserTestModels;

            var list = new List<GradebookTestResultModel>();

            foreach (var test in tests)
            {
                foreach (var testResult in testResults)
                {
                    if (
                        test.UnitName == testResult.UnitName &&
                        test.LessonName == testResult.LessonName)
                    {
                        
                    
                    var tempList = new List<LessonResultModel>();

                    foreach (var questionResult in testResult.QuestionResultModels)
                    {
                        foreach (var question in test.QuestionModels)
                        {
                            if (questionResult.Text == question.Text)
                            {
                                var correctAnswers = question.Options.Where(c => c.IsCorrect).Select(c => c.Name);

                                var firstNotSecond = correctAnswers.Except(questionResult.OptionsName).ToList();
                                var secondNotFirst = questionResult.OptionsName.Except(correctAnswers).ToList();

                                var result = !firstNotSecond.Any() && !secondNotFirst.Any();

                                var points = test.NumberOfPoints / test.NumberOfQuestions;

                                var pointResult = (result ? points : 0).ToString();

                                tempList.Add(new LessonResultModel()
                                {
                                    LessonNameAndPoint = string.Format(test.LessonName, "-" , pointResult,
                                        test.NumberOfQuestions),
                                }); 
                            }
                        }
                    }

                    list.Add(new GradebookTestResultModel()
                    {
                        UnitName = test.UnitName,
                        Lessons = tempList
                    });
                    }   
                }
            }

            return list;
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

                        var points = test.NumberOfPoints / test.NumberOfQuestions;

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