using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Awdk.Skus.Framework.Common.CustomException;
using Awdk.Skus.Framework.DataAccess.EF;
using Awdk.Skus.Framework.DataAccess.EF.Interface;
using Awdk.Skus.Framework.DataAccess.Repository.Interface;

namespace Awdk.Skus.Framework.DataAccess.Repository.Repository
{
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        #region Private Fields
        protected IDbContext _dbContext;
        #endregion

        #region ctor

        public GenericRepository(IDbContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _dbContext = context;
        }

        #endregion

        #region Retrieve Methods
        public TEntity GetById(TKey id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            if (entity == null)
            {
                throw Error.RecordNotFound(typeof(TEntity), typeof(TKey), id);
            }
            return entity;
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).Single();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }
        #endregion

        #region Save Methods
        public TEntity Insert(TEntity entity)
        {
            _dbContext.Entry(entity);
            if (entity == null) throw new ArgumentNullException("entity");
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual TEntity Update(TEntity valueObject)
        {
            _dbContext.Set<TEntity>().Attach(valueObject);
            _dbContext.Entry(valueObject).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return valueObject;
        }
        #endregion

        #region Delete Methods
        public bool DeleteById(TKey id)
        {
            var entity = GetById(id);
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Deleted;
            _dbContext.Set<TEntity>().Remove(entity);
            return true;
        }

        public bool Delete(TEntity entityToDeleted)
        {
            if (entityToDeleted == null) throw new ArgumentNullException("entity");
            if (_dbContext.Entry(entityToDeleted).State == EntityState.Detached)
            {
                _dbContext.Set<TEntity>().Attach(entityToDeleted);
            }
            _dbContext.Set<TEntity>().Remove(entityToDeleted);
            return true;
        }
        #endregion

        #region Disposable Pattern
        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
                _dbContext.Dispose();
            disposed = true;
        }
        #endregion
    }
}
