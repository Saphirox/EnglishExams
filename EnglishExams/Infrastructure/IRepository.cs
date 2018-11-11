using EnglishExams.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnglishExams.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : IntId
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> Add(IReadOnlyCollection<TEntity> entities);
        IQueryable<TEntity> GetQueryable();
        void Delete(TEntity entity);
    }
}