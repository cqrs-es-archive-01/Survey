using Survey.Transverse.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Survey.Transverse.Infrastracture.Data.Repositories
{
    public class FeatureRepository : GenericRepository<Feature>,IFeatureRepository
    {
        private readonly TransverseContext _context;

        public FeatureRepository(TransverseContext context):base(context)
        {
            _context = context;
        }

        public Feature FindByKey(Guid id)
        {
            return _context.Features.Find(id);
        }

        public void Insert(Feature entity)
        {
            _context.Features.Add(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        IEnumerable<Feature> IFeatureRepository.FindBy(Expression<Func<Feature, bool>> predicate)
        {
            return base.FindBy(predicate);
        }

        IEnumerable<Feature> IFeatureRepository.FindByInclude(Expression<Func<Feature, bool>> predicate, params Expression<Func<Feature, object>>[] includeProperties)
        {
            return base.FindByInclude(predicate, includeProperties);
        }


    }
}
