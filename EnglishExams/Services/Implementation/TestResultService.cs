using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EnglishExams.Application.Infrastructure;
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
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;
        
        public TestResultService(IUserService userService, IUnitOfWork uow)
        {
            _userService = userService;
            _uow = uow;
        }

        // TODO: Refactor me
        public void AddResultToUser(TestKey key, Dictionary<string, ICollection<string>> answers)
        {
            var newEntity = TestResultModel.CreateNew(key, answers.Select(c =>
                QuestionResultModel.CreateNew(c.Key, c.Value)).ToList());

            try
            {
                var existed = _uow.Repository<TestResultModel>().GetQueryable()
                        .Where(c => c.UserModel.Id == CurrentUser.Instance.Id && c.UnitName == key.UnitName &&
                                    c.LessonName == key.LessonName);

                if (existed.Any())
                {
                    _uow.Repository<TestResultModel>().Delete(existed.ToList());
                }

                newEntity.UserModel = _uow.Repository<UserModel>().GetQueryable().FirstOrDefault(CurrentUser.FindUser);
                _uow.Repository<TestResultModel>().Add(newEntity);
                _uow.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<GradebookTestResultModel> GetGradebook()
        {
            var tests = _uow.Repository<UserTestModel>().GetQueryable();

            var testResult = _uow.Repository<TestResultModel>().GetQueryable()
                .Include(c => c.UserModel)
                .Where(c => c.UserModel.Id == CurrentUser.Instance.Id);

            return GetOneGradebook(tests, testResult);
        }

        public IEnumerable<MasterGradebookTestResultModel> GetMasterGradebook()
        {
            var tests = _uow.Repository<UserTestModel>().GetQueryable().AsEnumerable();
            var pupils = _userService.FindStudents().ToArray();

            foreach (var pupil in pupils)
                pupil.TestResults = pupil.TestResults.ToArray();

            return pupils.Select(p => new MasterGradebookTestResultModel()
            {
                Results = GetOneGradebook(tests, p.TestResults),
                UserName = p.UserName
            });
        }

        public IList<TestResultDescriptionModel> GetResults(TestKey key)
        {
            var testResult = _uow.Repository<UserModel>()
                .GetQueryable()
                .Include(c => c.TestResults)
                .FirstOrDefault(CurrentUser.FindUser)
                .TestResults
                .LastOrDefault(c => c == key);

            // TODO: Refactor me
            var test = _userService.FindTeacher().UserTestModels.LastOrDefault(c => c == key);
            
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

                        var firstNotSecond = correctAnswers.Except(testResultQuestion.OptionsName.Select(c => c.Name)).ToList();
                        
                        var result = !firstNotSecond.Any();

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
                            UserResult = string.Concat(CommonResources.YourAnswer, ": ", string.Join(", ", testResultQuestion.OptionsName.Select(c => c.Name)))
                        });
                    }
                }
            }

            return list;
        }

        // TODO: Refactor me -> method cannot accept arrays
        private IEnumerable<GradebookTestResultModel> GetOneGradebook(IEnumerable<UserTestModel> tests, 
            IEnumerable<TestResultModel> testResults)
        {
            foreach (UserTestModel test in tests)
            {
                foreach (TestResultModel testResult in testResults)
                {
                    if (testResult == test)
                    {
                        int resultPoint = 0;

                        foreach (QuestionResultModel questionResult in testResult.QuestionResultModels)
                        {
                            foreach (QuestionModel question in test.QuestionModels)
                            {
                                if (questionResult.Text != question.Text)
                                    continue;

                                var correctAnswers = question.Options.Where(c => c.IsCorrect).Select(c => c.Name);
                                var questionPassed = questionResult.OptionsName.Select(c => c.Name).Except(correctAnswers).Any();
                                var points = test.NumberOfPoints / test.NumberOfQuestions;

                                resultPoint += questionPassed ? points : 0;
                            }
                        }

                        yield return GradebookTestResultModel.Factory.CreateNew(
                            TestKey.From(test.UnitName, test.LessonName),
                            resultPoint);
                    }
                }
            }
        }
    }
}