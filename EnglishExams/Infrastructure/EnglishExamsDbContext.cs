using EnglishExams.Models;
using System.Data.Entity;

namespace EnglishExams.Infrastructure
{
    public class EnglishExamsDbContext : DbContext
    {
        public EnglishExamsDbContext()
        {

        }

        public IDbSet<UserTestModel> UserTestModels { get; set; }
        public IDbSet<OptionModel> OptionModels { get; set; }
        public IDbSet<QuestionModel> QuestionModels { get; set; }
        public IDbSet<QuestionResultModel> QuestionResultModels { get; set; }
        public IDbSet<TestListModel> TestListModels { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
    }
}
