using Survey.Transverse.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Survey.Transverse.Domain.Features
{
    public interface IPermissionRepository
    {
        Permission FindByKey(Guid id);
        void Insert(Permission entity);
        void UpdateFeatures(Permission entity,bool deleteExisting);

        IEnumerable<Permission> FindByInclude(Expression<Func<Permission, bool>> predicate, params Expression<Func<Permission, object>>[] includeProperties);
        IEnumerable<Permission> FindBy(Expression<Func<Permission, bool>> predicate);

        bool Save();
    }
}
