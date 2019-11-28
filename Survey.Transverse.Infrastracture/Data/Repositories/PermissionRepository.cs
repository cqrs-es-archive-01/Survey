using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Survey.Transverse.Infrastracture.Data.Repositories
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly TransverseContext _context;

        public PermissionRepository(TransverseContext context) :base(context)
        {
            _context = context;
        }


        public Permission FindByKey(Guid id)
        {
           return  _context.Permissions.Find(id);
        }

        public void Insert(Permission entity)
        {
            _context.Permissions.Add(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges()>0;
        }

        public void UpdateFeatures(Permission entity,bool deleteExisting=false)
        {
            var existingFeatures = _context.PermissionFeatures.Where(a => a.PermissionId == entity.Id).ToList();

            List<PermissionFeature> itemsToRemove = new List<PermissionFeature>();
            List<PermissionFeature> itemsToInsert = new List<PermissionFeature>();

            itemsToInsert = entity.PermissionFeatures.Where(a => existingFeatures.
                Where(x => x.FeatureId == a.FeatureId).Count() == 0).ToList();


            if (deleteExisting)
            {
                itemsToRemove = existingFeatures.Where(a => entity.PermissionFeatures.
                      Where(x => x.FeatureId == a.FeatureId).Count() == 0).ToList();
            }
            if (itemsToRemove.Count > 0 || itemsToInsert.Count > 0)
            {
                _context.PermissionFeatures.RemoveRange(itemsToRemove);
                _context.PermissionFeatures.AddRange(itemsToInsert);
            }
        }

        IEnumerable<Permission> IPermissionRepository.FindBy(Expression<Func<Permission, bool>> predicate)
        {
            return base.FindBy(predicate);
        }

        IEnumerable<Permission> IPermissionRepository.FindByInclude(Expression<Func<Permission, bool>> predicate, params Expression<Func<Permission, object>>[] includeProperties)
        {
            return base.FindByInclude(predicate, includeProperties);
        }
    }
}
