using Microsoft.Extensions.DependencyInjection;
using Survey.API.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Transverse.API._Configuration
{
    public static class TokenFactoryConfiguration
    {
        public static IServiceCollection AddTokenFactory(this IServiceCollection services)
        {
            services.AddTransient(typeof(ITokenFactory), typeof(TokenFactory));

            return services;
        }

    }
}
