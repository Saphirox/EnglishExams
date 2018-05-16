using System;
using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Services.Implementation
{
    public class TestListService : ITestListService
    {
        private readonly IUserService userService;

        public TestListService(IUserService userService)
        {
            this.userService = userService;
        }

        public IEnumerable<UserTestModel> GetListByTeacher()
        {
            var teacher = userService.FindTeacher();

            if (teacher == null)
            {
                throw new InvalidOperationException();
            }

            return teacher.UserTestModels;
        }
    }
}