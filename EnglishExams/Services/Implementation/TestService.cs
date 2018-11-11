using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EnglishExams.Application.Infrastructure;
using EnglishExams.Infrastructure;
using EnglishExams.Models;

namespace EnglishExams.Services.Implementation
{
    /// <summary>
    /// Perform action on QuestionModels
    /// </summary>
    public class TestService : ITestService
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;

        public TestService(IUnitOfWork uow, IUserService userService)
        {
            _uow = uow;
            _userService = userService;
        }

        public UserTestModel Add(UserTestModel userTestModel)
        {
            UserTestModel model;

            try
            {
                if (userTestModel is null)
                    throw new ArgumentNullException(nameof(userTestModel));

                var teacher = _uow.Repository<UserModel>()
                    .GetQueryable()
                    .FirstOrDefault(u => u.Id == CurrentUser.Instance.Id);

                userTestModel.UserModel = teacher;
                model = _uow.Repository<UserTestModel>().Add(userTestModel);
                _uow.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return model;
        }

        public UserTestModel GetTestByTaskDescription(TestKey key)
        {
            var test = _userService.FindTeacher()?.UserTestModels.FirstOrDefault(c => c == key);

            if (test is null)
            {
                throw new InvalidOperationException();
            }

            return test;
        }

        public UserTestModel GetTestByTaskDescriptionWithPermution(TestKey key)
        {
            var userTestModel = GetTestByTaskDescription(key);

            if (!userTestModel.Permuted)
                return userTestModel;

            var questions = userTestModel.QuestionModels.ToList();

            var random = new Random();

            for (int i = 0; i < questions.Count; i++)
            {
                var pivot = random.Next(0, questions.Count);

                var temp = questions[pivot];
                questions[pivot] = questions[i];
                questions[i] = temp;
            }

            userTestModel.QuestionModels = questions;

            return userTestModel;
        }
    }
}