using Survey.Transverse.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Survey.Transverse.Infrastracture.Data.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly TransverseContext _context;

        public UserRepository(TransverseContext context):base(context)
        {
            _context = context;
        }

        public bool DoesUserHaveAccessTo(Guid userId,string actionName)
        {
            return (from x in _context.Features
                    join y in _context.PermissionFeatures on x.Id equals y.FeatureId
                    join z in _context.UserPermissions on y.PermissionId equals z.PermissionId
                    where z.UserId == userId && x.Action == actionName
                    select new
                    {
                        x.Id
                    }).Count() > 0;
        }


        public User FindByKey(Guid id)
        {
            return _context.Users.Find(id);

        }

        public void Insert(User entity)
        {
            _context.Users.Add(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdatePermissions(User entity, bool deleteExisting)
        {
            var existingPermissions = _context.UserPermissions.Where(a => a.PermissionId == entity.Id).ToList();

            List<UserPermission> itemsToRemove = new List<UserPermission>();
            List<UserPermission> itemsToInsert = new List<UserPermission>();

            itemsToInsert = entity.UserPermissions.Where(a => existingPermissions.
                Where(x => x.PermissionId == a.PermissionId).Count() == 0).ToList();


            if (deleteExisting)
            {
                itemsToRemove = existingPermissions.Where(a => entity.UserPermissions.
                      Where(x => x.PermissionId == a.PermissionId).Count() == 0).ToList();
            }
            if (itemsToRemove.Count > 0 || itemsToInsert.Count > 0)
            {
                _context.UserPermissions.RemoveRange(itemsToRemove);
                _context.UserPermissions.AddRange(itemsToInsert);
            }
        }
        IEnumerable<User> IUserRepository.FindBy(Expression<Func<User, bool>> predicate)
        {
            return base.FindBy(predicate);
        }

        IEnumerable<User> IUserRepository.FindByInclude(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties)
        {
            return base.FindByInclude(predicate, includeProperties);
        }

    }
}
