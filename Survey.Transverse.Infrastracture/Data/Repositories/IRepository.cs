using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Survey.Transverse.Infrastracture.Data.Repositories
{
    internal interface IRepository<TEntity> 
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}
