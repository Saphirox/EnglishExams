using EnglishExams.Models;

namespace EnglishExams.Services
{
    public interface IUserService
    {
        void Add(UserModel model);
        UserModel FindTeacher();
        void Update(UserModel model);
        void Authenticate(UserModel model);
    }
}