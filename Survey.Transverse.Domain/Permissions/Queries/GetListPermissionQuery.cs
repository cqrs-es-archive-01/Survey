using Survey.Common.Types;
using Survey.Transverse.Contract.Permissions.Responses;
using System;
using System.Collections.Generic;

namespace Survey.Transverse.Domain.Features.Queries
{
    public sealed class GetListPermissionQuery : IQuery<List<PermissionListResponse>>
    {
        public GetListPermissionQuery()
        {

        }
    }
}
