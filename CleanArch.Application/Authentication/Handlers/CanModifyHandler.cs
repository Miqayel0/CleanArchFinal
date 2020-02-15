using CleanArch.Application.Authentication.Requirements;
using CleanArch.Application.Permissions;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Entities.PermissionAggregation;
using CleanArch.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Application.Authentication.Handlers
{
    public class CanModifyHandler : AuthorizationHandler<CanModifyRequirament>
    {
        private readonly IAsyncRepository _repository;

        public CanModifyHandler(IAsyncRepository repository)
        {
            _repository = repository;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CanModifyRequirament requirement)
        {
            var roles = await _repository
                 .Filter<Permission>(x => x.Name == nameof(AppPermission.CanModifyUser))
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
