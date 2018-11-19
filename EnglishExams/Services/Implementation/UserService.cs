using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EnglishExams.Application.Infrastructure;
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
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(UserModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            _uow.Repository<UserModel>().Add(model);
            _uow.SaveChanges();
        }

        public void Update(UserModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            
            var entity = _uow.Repository<UserModel>()
                .GetQueryable()
                .FirstOrDefault(m => m.Password == model.Password &&
                                                  m.UserName == model.UserName);

            entity.UpdateFrom(model);
            _uow.SaveChanges();
        }

        public void Authenticate(UserModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var user = _uow.Repository<UserModel>().GetQueryable().FirstOrDefault(
                                                  m => m.Password == model.Password && 
                                                  m.UserName == model.UserName);

            CurrentUser.Instance = user;
        }

        public IEnumerable<UserModel> FindStudents()
        {
            var students = _uow.Repository<UserModel>().GetQueryable().Where(c => c.Role == Roles.Student);

            return students;
        }


        // TODO: Move to model
        public bool IsTeacher(string userName, string password)
        {
            return _uow.Repository<UserModel>().GetQueryable().Any(c => c.UserName == userName &&
                                                      c.Password == password &&
                                                      c.Role == Roles.Master);
        }

        public UserModel FindTeacher()
        {
            var teacher = _uow.Repository<UserModel>().GetQueryable()
                .Include(c => c.UserTestModels)
                .AsNoTracking()
                .FirstOrDefault(c => c.Role == Roles.Master);

            return teacher;
        }
    }
}