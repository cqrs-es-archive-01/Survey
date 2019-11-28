using Microsoft.Extensions.DependencyInjection;
using Survey.API._Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Transverse.API._Configuration
{
    public static class HttpContextHelperConfiguration
    {
        public static IServiceCollection AddHttpContextHelper(this IServiceCollection services)
        {
            services.AddTransient<HttpContextHelper, HttpContextHelper>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
