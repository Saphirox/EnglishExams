using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnglishExams.Common;
using EnglishExams.Models;
using Newtonsoft.Json;

namespace EnglishExams.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly IFileFacade _fileFacade;

        public UserService(IFileFacade fileFacade)
        {
            _fileFacade = fileFacade;
        }

        public void Add(UserModel model)
        {
            var models = 
                _fileFacade.ReadFrom<IEnumerable<UserModel>>(FileConstants.PERSONAL_DATA)?.ToList();

            if (models is null)
            {
                models = new List<UserModel>();
            }

            models.Add(model);

            _fileFacade.WriteTo(FileConstants.PERSONAL_DATA, models);
        }//

    }
}