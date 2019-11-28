using Dapper;
using Survey.Common.Types;
using Survey.Transverse.Contract.Features.Responses;
using Survey.Transverse.Contract.Users.Responses;
using Survey.Transverse.Domain.Features.Queries;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Queries;
using Survey.Transverse.Service.Users;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Survey.Transverse.Service.Features.Queries
{
    public sealed class GetFeatureByIdQueryHandler : IQueryHandler<GetFeatureByIdQuery, FeatureResponse>
    {
        private readonly QueriesConnectionString _connectionString;

        public GetFeatureByIdQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public FeatureResponse Handle(GetFeatureByIdQuery query)
        {
            string sql = @"
                    select Id,
	                       Label,
	                       Description,
	                       Controller,
	                       ControllerActionName,
	                       Action,
	                       CreatedBy
                    FROM [Identity].[FEATURES]
                    where Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                FeatureResponse feature = connection
                        .Query<FeatureResponse>(sql, new
                        {
                            Id = query.Id
                        })
                        .FirstOrDefault();

                return feature;
            }
        }
    }
}
