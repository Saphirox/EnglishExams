using EnglishExams.Infrastructure;
using EnglishExams.Models;

namespace EnglishExams.Application.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : IntId;
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void SaveChanges();
    }
}
