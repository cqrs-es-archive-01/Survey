using Survey.Transverse.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Survey.Transverse.Domain.Features
{
    public interface IFeatureRepository
    {
        Feature FindByKey(Guid id);
        void Insert(Feature entity);
        IEnumerable<Feature> FindByInclude(Expression<Func<Feature, bool>> predicate, params Expression<Func<Feature, object>>[] includeProperties);
        IEnumerable<Feature> FindBy(Expression<Func<Feature, bool>> predicate);

        bool Save();
    }
}
