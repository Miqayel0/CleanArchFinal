using CleanArch.Application.Authentication.Requirements;
using CleanArch.Application.Permissions;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Application.Authentication.Handlers
{
    public class CanModifyUserHandler : AuthorizationHandler<CanModifyUserRequirament>
    {
        private readonly IAsyncRepository _repository;

        public CanModifyUserHandler(IAsyncRepository repository)
        {
            _repository = repository;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CanModifyUserRequirament requirement)
        {
            var roles = await _repository
                 .Filter<Permission>(x => x.Name == nameof(AppPerrmision.CanModifyUser))
                 .SelectMany(x => x.Roles)
                 .Select(x => x.Name)
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
