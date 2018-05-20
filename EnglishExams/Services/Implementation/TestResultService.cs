using System.Collections.Generic;
using System.Linq;
using EnglishExams.Infrastructure;
using EnglishExams.Models;
using EnglishExams.Resources;

namespace EnglishExams.Services.Implementation
{
    /// <summary>
    /// Perform action on TestResult
    /// </summary>
    public class TestResultService : ITestResultService
    {
        private readonly IFileWrapper _fileWrapper;
        private readonly IUserService _userService;

        public TestResultService(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
            _userService = new UserService(_fileWrapper);
        }

        public void AddResultToUser(TestKey key, Dictionary<string, ICollection<string>> answers)
        {
            var testResult = new TestResultModel
            {
                Key = key,
                QuestionResultModels = answers.Select(c => new QuestionResultModel
                {
                    Text = c.Key,
                    OptionsName = c.Value
                }).ToList()
            };

            var existed = CurrentUser.Instance.TestResults.FirstOrDefault(c => c.Key == key);

            if (existed != null)
            {
                CurrentUser.Instance.TestResults.Remove(existed);
            }

            CurrentUser.Instance.TestResults.Add(testResult);

            _userService.Update(CurrentUser.Instance);
        }

        public IEnumerable<GradebookTestResultModel> GetGradebook()
        {
            var user = CurrentUser.Instance;
            user.TestResults = user.TestResults.Reverse().Distinct().ToArray();
            var teacherTests = _userService.FindTeacher()
                .UserTestModels
                .ToList();

            teacherTests.Reverse();

            var tests = teacherTests.Distinct().ToArray();

            return GetOneGradebook(tests, user.TestResults);
        }

        public IEnumerable<MasterGradebookTestResultModel> GetMasterGradebook()
        {
            var teacherTests = _userService.FindTeacher()
                .UserTestModels
                .ToList();

            teacherTests.Reverse();

            var tests = teacherTests.Distinct().ToArray();

            var pupils = _userService.FindStudents().ToArray();

            foreach (var pupil in pupils)
            {
                pupil.TestResults = pupil.TestResults.Reverse().Distinct().ToArray();
            }

            return pupils.Select(p => new MasterGradebookTestResultModel()
            {
                Results = GetOneGradebook(tests, p.TestResults),
                UserName = p.UserName
            });
        }

        public IList<TestResultDescriptionModel> GetResults(TestKey key)
        {
            var testResult = CurrentUser.Instance.TestResults.LastOrDefault(c => c.Key == key);

            var test = _userService.FindTeacher().UserTestModels.LastOrDefault(c => c.Key == key);
            
            var list = new List<TestResultDescriptionModel>();
            var index = 0;

            foreach (var testQuestion in test.QuestionModels)
            {
                foreach (var testResultQuestion in testResult.QuestionResultModels)
                {
                    if (testResultQuestion.Text == testQuestion.Text)
                    {
                        var correctAnswers = testQuestion.Options
                            .Where(c => c.IsCorrect)
                            .Select(c => c.Name)
                            .ToArray();

                        var firstNotSecond = correctAnswers.Except(testResultQuestion.OptionsName).ToList();
                        var secondNotFirst = testResultQuestion.OptionsName.Except(correctAnswers).ToList();
                        
                        var result = !firstNotSecond.Any() && !secondNotFirst.Any();

                        ++index;

                        var points = test.NumberOfPoints / test.NumberOfQuestions;

                        var pointResult = (result ? points : default).ToString();

                        list.Add(new TestResultDescriptionModel
                        {
                            QuestionNumber = string.Concat(CommonResources.Question, " ", index.ToString(),
                                "/", test.NumberOfQuestions.ToString()),
                            IsCorrect = result,
                            QuestionName = testQuestion.Text,
                            CorrectResult = string.Concat(CommonResources.CorrectAnswer, ": ", string.Join(", ", correctAnswers)),
                            QuestionPoints = string.Format(CommonResources.YouGotPattern, pointResult, 
                                test.NumberOfPoints / test.NumberOfQuestions),
                            UserResult = string.Concat(CommonResources.YourAnswer, ": ", string.Join(", ", testResultQuestion.OptionsName))
                        });
                    }
                }
            }

            return list;
        }

        private IEnumerable<GradebookTestResultModel> GetOneGradebook(IEnumerable<UserTestModel> tests, 
            IEnumerable<TestResultModel> testResults)
        {
            foreach (var test in tests)
            {
                foreach (var testResult in testResults)
                {
                    if (testResult.Key == test.Key)
                    {
                        int resultPoint = 0;

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

                                    resultPoint += result ? points : 0;
                                }
                            }
                        }

                        yield return new GradebookTestResultModel
                        {
                            Key = test.Key,
                            Points = resultPoint
                        };
                    }
                }
            }
        }
    }
}