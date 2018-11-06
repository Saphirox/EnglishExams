using System;
using System.Collections.Generic;
using System.Linq;
using EnglishExams.Common;
using EnglishExams.Infrastructure;
using EnglishExams.Models;

namespace EnglishExams.Services.Implementation
{
    /// <summary>
    /// Perform action on User
    /// </summary>
    public class UserService : IUserService
    {
        private readonly EnglishExamsDbContext _englishExamsDbContext;

        public UserService(EnglishExamsDbContext englishExamsDbContext)
        {
            _englishExamsDbContext = englishExamsDbContext;
        }

        public void Add(UserModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            _englishExamsDbContext.UserModels.Add(model);
            _englishExamsDbContext.SaveChanges();
        }

        public void Update(UserModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            
            var entity = _englishExamsDbContext.UserModels.FirstOrDefault(m => m.Password == model.Password &&
                                                  m.UserName == model.UserName);

            entity.UpdateFrom(model);
            _englishExamsDbContext.SaveChanges();
        }

        public void Authenticate(UserModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var user = _englishExamsDbContext.UserModels.AsNoTracking().FirstOrDefault(
                                                  m => m.Password == model.Password && 
                                                  m.UserName == model.UserName);

            CurrentUser.Instance = user;
        }

        public IEnumerable<UserModel> FindStudents()
        {
            var students = _englishExamsDbContext.UserModels.Where(c => c.Role == Roles.Student);

            return students;
        }

        public bool IsTeacher(string userName, string password)
        {
            return _englishExamsDbContext.UserModels.Any(c => c.UserName == userName &&
                                                      c.Password == password &&
                                                      c.Role == Roles.Master);
        }

        public UserModel FindTeacher()
        {
            var teacher = _englishExamsDbContext.UserModels.FirstOrDefault(c => c.Role == Roles.Master);

            return teacher;
        }
    }
}