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
        private readonly IFileWrapper _fileWrapper;

        public UserService(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
        }

        public void Add(UserModel model)
        {
            var models = 
                _fileWrapper.ReadFrom<IEnumerable<UserModel>>(FileConstants.PERSONAL_DATA)
                    ?.ToList() ?? new List<UserModel>();

            models.Add(model);

            _fileWrapper.WriteTo(FileConstants.PERSONAL_DATA, models);
        }

        public void Update(UserModel model)
        {
            var models =
                _fileWrapper.ReadFrom<IEnumerable<UserModel>>(FileConstants.PERSONAL_DATA)?.ToList();

            if (models == null)
            {
                throw new InvalidOperationException();
            }

            var index = models.FindIndex(m => m.Password == model.Password &&
                                                  m.UserName == model.UserName);
            models[index] = model;

            _fileWrapper.WriteTo(FileConstants.PERSONAL_DATA, models);
        }

        public void Authenticate(UserModel model)
        {
            var models =
                _fileWrapper.ReadFrom<IEnumerable<UserModel>>(FileConstants.PERSONAL_DATA)?.ToList();


            var user = models?.FirstOrDefault(m => m.Password == model.Password && 
                                                  m.UserName == model.UserName);

            CurrentUser.Instance = user;
        }

        public IEnumerable<UserModel> FindStudents()
        {
            var models =
                _fileWrapper.ReadFrom<IEnumerable<UserModel>>(FileConstants.PERSONAL_DATA).ToList();

            var students = models.Where(c => c.Role == Roles.Student);

            return students;
        }

        public bool IsTeacher(string userName, string password)
        {
            var models =
                _fileWrapper.ReadFrom<IEnumerable<UserModel>>(FileConstants.PERSONAL_DATA)?.ToList();

            var teacher = models?.FirstOrDefault(c => c.UserName == userName && 
                                                      c.Password == password);

            return teacher != null;
        }

        public UserModel FindTeacher()
        {
            var models =
                _fileWrapper.ReadFrom<IEnumerable<UserModel>>(FileConstants.PERSONAL_DATA)?.ToList();

            var teacher = models?.FirstOrDefault(c => c.Role == Roles.Master);

            return teacher;
        }
    }
}