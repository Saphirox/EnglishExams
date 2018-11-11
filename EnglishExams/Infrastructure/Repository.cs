using EnglishExams.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishExams.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: IntId
    {
        protected DbContext DbContext;

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            return DbContext.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> Add(IReadOnlyCollection<TEntity> entities)
        {
            return DbContext.Set<TEntity>().AddRange(entities);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return DbContext.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbContext.Set<TEntity>().Attach(entity);
            }

            DbContext.Set<TEntity>().Remove(entity);
        }
    }
}
