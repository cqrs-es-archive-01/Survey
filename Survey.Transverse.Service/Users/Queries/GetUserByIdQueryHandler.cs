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
    public sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly QueriesConnectionString _connectionString;

        public GetUserByIdQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public UserResponse Handle(GetUserByIdQuery query)
        {
            string sql = @"
                    Select Top 1 Id,
	                       FirstName,
	                       LastName,
	                       Email 
                    From [Identity].[USERS]
                    where Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                UserResponse user = connection
                        .Query<UserResponse>(sql, new
                        {
                            Id = query.Id
                        })
                        .FirstOrDefault();

                return user;
            }
        }
    }
}
