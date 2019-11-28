using Dapper;
using Survey.Common.Types;
using Survey.Transverse.Contract.Users.Responses;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Survey.Transverse.Service.Users.Queries
{
    public sealed class GetAllUsersQueryHandler : IQueryHandler<GetListUsersQuery, List<UserListResponse>>
    {
        private readonly QueriesConnectionString _connectionString;
     
        public GetAllUsersQueryHandler(QueriesConnectionString  queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public List<UserListResponse> Handle(GetListUsersQuery query)
        {
            string sql = @"
                    Select Id,
	                       FirstName,
	                       LastName,
	                       Email 
                    From [Identity].[USERS]";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                List<UserListResponse> users = connection
                    .Query<UserListResponse>(sql).ToList();

                return users;
            }
        }
    }
}
