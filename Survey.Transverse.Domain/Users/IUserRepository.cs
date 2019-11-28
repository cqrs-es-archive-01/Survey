using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Transverse.Domain.Users
{
    public interface  IUserRepository
    {
        User FindByKey(Guid id);
        void Insert(User entity);
        void UpdatePermissions(User entity,bool deleteExisting);
        IEnumerable<User> FindByInclude(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties);
        IEnumerable<User> FindBy(Expression<Func<User, bool>> predicate);

        bool Save();
        bool DoesUserHaveAccessTo(Guid userId,string actionName);
    }
}
