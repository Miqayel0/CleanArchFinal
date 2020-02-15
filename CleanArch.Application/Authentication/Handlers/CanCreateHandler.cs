using CleanArch.Application.Authentication.Requirements;
using CleanArch.Application.Permissions;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Entities.PermissionAggregation;
using CleanArch.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CleanArch.Application.Authentication.Handlers
{
    public class CanCreateHandler : AuthorizationHandler<CanCreateRequirament>
    {
        private readonly IAsyncRepository _repository;

        public CanCreateHandler(IAsyncRepository repository)
        {
            _repository = repository;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CanCreateRequirament requirement)
        {
            var roles = await _repository
                 .Filter<Permission>(x => x.Name == nameof(AppPermission.CanCreate))
                 .SelectMany(x => x.PermissionRoles)
                 .Select(x => x.Role.Name)
                 .ToListAsync();

            foreach (var item in roles)
            {
                if (context.User.IsInRole(item))
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}

