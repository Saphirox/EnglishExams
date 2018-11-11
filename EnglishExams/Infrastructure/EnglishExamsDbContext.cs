using EnglishExams.Models;
using System.Data.Entity;

namespace EnglishExams.Infrastructure
{
    public class EnglishExamsDbContext : DbContext
    {
        public EnglishExamsDbContext(string connectionString) : base(connectionString)
        {
        }

        public IDbSet<UserTestModel> UserTestModels { get; set; }
        public IDbSet<OptionModel> OptionModels { get; set; }
        public IDbSet<QuestionModel> QuestionModels { get; set; }
        public IDbSet<QuestionResultModel> QuestionResultModels { get; set; }
        public IDbSet<TestListModel> TestListModels { get; set; }
        public IDbSet<UserModel> UserModels { get; set; }
        public IDbSet<OptionName> OptionNames { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<QuestionResultModel>().HasMany(q => q.OptionsName)
                .WithRequired(o => o.QuestionResultModel)
                .HasForeignKey(o => o.QuestionResultModelId)
                .WillCascadeOnDelete(true);

            mb.Entity<TestResultModel>().HasMany(q => q.QuestionResultModels)
                .WithRequired(t => t.TestResult)
                .HasForeignKey(c => c.TestResultId)
                .WillCascadeOnDelete(true);
        }
    }
}
