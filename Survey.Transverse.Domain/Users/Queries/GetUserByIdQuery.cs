using Survey.Common.Types;
using Survey.Transverse.Contract.Users.Responses;
using System;

namespace Survey.Transverse.Domain.Users.Queries
{
    public sealed class GetUserByIdQuery:IQuery<UserResponse>
    {
        public Guid Id { get;private set; }
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
