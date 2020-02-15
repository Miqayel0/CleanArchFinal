using CleanArch.Application.Authentication.Handlers;
using CleanArch.Application.Authentication.Requirements;
using CleanArch.Application.Permissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IAuthorizationHandler, CanModifyHandler>();
            services.AddScoped<IAuthorizationHandler, CanCreateHandler>();

            services.AddAuthorizationCore(options =>
            {
                options.AddPolicy(nameof(AppPermission.CanModifyUser), policy =>
                    policy.Requirements.Add(new CanModifyRequirament()));
                options.AddPolicy(nameof(AppPermission.CanCreate), policy =>
                    policy.Requirements.Add(new CanCreateRequirament()));
            });
            
            return services;
        }
    }
}
