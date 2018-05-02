using EnglishExams.Models;

namespace EnglishExams.Services
{
    public interface IUserService
    {
        void Add(UserModel model);
        void Update(UserModel model);
        void Authenticate(UserModel model);
    }
}