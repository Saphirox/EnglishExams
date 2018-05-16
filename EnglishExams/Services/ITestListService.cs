using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Services
{
    public interface ITestListService
    {
        IEnumerable<UserTestModel> GetListByTeacher();
    }
}