using Dapper;
using Survey.Common.Types;
using Survey.Transverse.Contract.Permissions.Responses;
using Survey.Transverse.Domain.Features.Queries;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Survey.Transverse.Service.Users.Queries
{
    public sealed class GetListPermissionQueryHandler : IQueryHandler<GetListPermissionQuery, List<PermissionListResponse>>
    {
        private readonly QueriesConnectionString _connectionString;
     
        public GetListPermissionQueryHandler(QueriesConnectionString  queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public List<PermissionListResponse> Handle(GetListPermissionQuery query)
        {
            string sql = @"
                    select Id,
	                       Label,
	                       Description
                    FROM [Identity].[PERMISSIONS]";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                List<PermissionListResponse> features = connection
                    .Query<PermissionListResponse>(sql).ToList();

                return features;
            }
        }
    }
}
