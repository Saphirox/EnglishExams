using System;
using System.Collections.Generic;
using System.Linq;
using EnglishExams.Common;
using EnglishExams.Models;

namespace EnglishExams.Infrastructure
{
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
                _fileWrapper.ReadFrom<IEnumerable<UserModel>>(FileConstants.PERSONAL_DATA)?.ToList();

            if (models is null)
            {
                models = new List<UserModel>();
            }

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

    }
}