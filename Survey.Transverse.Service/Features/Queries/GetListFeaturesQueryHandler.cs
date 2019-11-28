using Dapper;
using Survey.Common.Types;
using Survey.Transverse.Contract.Features.Responses;
using Survey.Transverse.Contract.Users.Responses;
using Survey.Transverse.Domain.Features.Queries;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Survey.Transverse.Service.Users.Queries
{
    public sealed class GetListFeaturesQueryHandler : IQueryHandler<GetListFeaturesQuery, List<FeatureListResponse>>
    {
        private readonly QueriesConnectionString _connectionString;
     
        public GetListFeaturesQueryHandler(QueriesConnectionString  queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public List<FeatureListResponse> Handle(GetListFeaturesQuery query)
        {
            string sql = @"
                    select Id,
	                       Label,
	                       Action,
	                       CreatedBy
                    FROM [Identity].[FEATURES]";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                List<FeatureListResponse> features = connection
                    .Query<FeatureListResponse>(sql).ToList();

                return features;
            }
        }
    }
}
