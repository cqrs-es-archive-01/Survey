using Microsoft.EntityFrameworkCore;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Survey.Transverse.Infrastracture.Data.Repositories
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly TransverseContext _context;

        private DbSet<TEntity> _entities;

        public GenericRepository(TransverseContext context)
        {
            this._context = context;
        }

        public DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();

                return _entities;
            }
        }

        public IQueryable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IQueryable<TEntity> results = query.Where(predicate);
            return results;
        }
        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = Entities;

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> results = Entities
            .Where(predicate);
            return results;
        }

    }
}
