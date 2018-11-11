using System;
using System.Collections.Generic;
using System.Data.Entity;
using EnglishExams.Application.Infrastructure;
using EnglishExams.Infrastructure;
using EnglishExams.Models;

namespace LittleSocialNetwork.DataAccess.EF.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories;
        private DbContextTransaction _transaction;
        private object _createdRepositoryLock;
        private bool _transactionClosed;
        private readonly DbContext _dbContext;

        public UnitOfWork(EnglishExamsDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, object>();
            _createdRepositoryLock = new object();
            _transactionClosed = true;
            _transaction = null;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity :  IntId
        {
            if (!_repositories.ContainsKey(typeof(TEntity)))
            {
                lock (_createdRepositoryLock)
                {
                    if (!_repositories.ContainsKey(typeof(TEntity)))
                    {
                        _repositories.Add(typeof(TEntity), new Repository<TEntity>(_dbContext));
                    }
                }
            }

            return _repositories[typeof(TEntity)] as IRepository<TEntity>;
        }

        public void BeginTransaction()
        {
            if (_transactionClosed || _transaction == null)
            {
                _transaction = _dbContext.Database.BeginTransaction();
                _transactionClosed = false;
            }
        }

        public void CommitTransaction()
        {
            if (!_transactionClosed)
            {
                _transaction?.Commit();
                _transactionClosed = true;
            }
        }

        public void RollbackTransaction()
        {
            if (!_transactionClosed)
            {
                _transaction?.Rollback();
                _transactionClosed = true;
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}