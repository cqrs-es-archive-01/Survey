using Survey.Common.Types;
using Survey.Transverse.Contract.Features.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Features.Queries
{
    public sealed class GetFeatureByIdQuery : IQuery<FeatureResponse>
    {
        public Guid Id { get;  }
        public GetFeatureByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
