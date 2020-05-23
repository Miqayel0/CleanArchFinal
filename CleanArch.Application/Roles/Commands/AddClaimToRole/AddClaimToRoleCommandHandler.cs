using Ardalis.GuardClauses;
using CleanArch.Application.Roles.Commands.AddClaimToRole;
using CleanArch.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace CleanArch.Application.Roles.Commands
{
    public class AddClaimToRoleCommandHandler : IRequestHandler<AddClaimToRoleCommand, bool>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AddClaimToRoleCommandHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(AddClaimToRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId);

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    foreach (var claim in request.Claims)
                    {
                        Guard.Against.NullOrEmpty(claim, nameof(request.Claims));
                        await _roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, claim));
                    }

                    scope.Complete();
                }
                catch (Exception)
                {
                    scope.Dispose();
                    throw;
                }
            }

            return true;
        }
    }
}
