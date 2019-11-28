using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Survey.Transverse.API.Validations.Authentication;
using Survey.Transverse.API.Validations.Features;
using Survey.Transverse.API.Validations.Users;
using Survey.Transverse.Contract.Features.Requests;
using Survey.Transverse.Contract.Identity.Requests;
using Survey.Transverse.Contract.Permissions.Requests;
using Survey.Transverse.Contract.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Transverse.API._Configuration
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<SignInRequest>, SignInValidator>();
            services.AddSingleton<IValidator<UserRegistrationRequest>, UserRegistrationValidator>();
            services.AddSingleton<IValidator<UnregisterRequest>, UnregisterValidator>();
            services.AddSingleton<IValidator<EditUserRequest>, EditUserValidator>();

            services.AddSingleton<IValidator<CreateFeatureRequest>, CreateFeatureValidator>();
            services.AddSingleton<IValidator<EditFeatureRequest>, EditFeatureValidator>();
            services.AddSingleton<IValidator<RemoveFeatureRequest>, RemoveFeatureValidator>();


            services.AddSingleton<IValidator<CreatePermissionRequest>, CreatePermissionValidator>();
            services.AddSingleton<IValidator<EditPermissionRequest>, EditPermissionValidator>();
            services.AddSingleton<IValidator<RemovePermissionRequest>, RemovePermissionValidator>();

            services.AddSingleton<IValidator<EditUserRequest>, EditUserValidator>();
            services.AddSingleton<IValidator<UnregisterRequest>, UnregisterValidator>();
            services.AddSingleton<IValidator<UserRegistrationRequest>, UserRegistrationValidator>();


            return services;
        }
    }
}
