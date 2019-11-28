using Microsoft.Extensions.DependencyInjection;
using Survey.API.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Transverse.API._Configuration
{
    public static class AuthFiltersConfiguration
    {
        public static IServiceCollection AddAuthFilters(this IServiceCollection services)
        {
            services.AddTransient<AuthorizeAccesAttribute, AuthorizeAccesAttribute>();

            return services;
        }
    }
}
