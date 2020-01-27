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
            services.AddScoped<IAuthorizationHandler, CanModifyUserHandler>();
            services.AddAuthorizationCore(options =>
            {
                options.AddPolicy(nameof(AppPerrmision.CanModifyUser), policy =>
                    policy.Requirements.Add(new CanModifyUserRequirament()));
            });
            
            return services;
        }
    }
}
