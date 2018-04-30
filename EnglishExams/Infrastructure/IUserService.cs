using EnglishExams.Models;

namespace EnglishExams.Infrastructure
{
    public interface IUserService
    {
        void Add(UserModel model);
    }
}