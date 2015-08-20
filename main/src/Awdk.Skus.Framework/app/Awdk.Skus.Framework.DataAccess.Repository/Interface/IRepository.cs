using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Awdk.Skus.Framework.DataAccess.Repository.Interface
{
    public interface IRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        #region Retrieve Methods
        TEntity GetById(TKey id);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Save Methods
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity valueObject);
        #endregion

        #region Delete Methods
        bool DeleteById(TKey id);
        bool Delete(TEntity entityToDeleted);
        #endregion
    }
}
