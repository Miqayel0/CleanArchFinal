using CleanArch.Application.Roles;
using CleanArch.Domain.Exeptions;
using CleanArch.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace CleanArch.Application.Account.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname
            };

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var userResult = await _userManager.CreateAsync(user, request.Password);
                    if (!userResult.Succeeded)
                        throw new SmartException(string.Join(Environment.NewLine, userResult.Errors));

                    var roleResult = await _userManager.AddToRoleAsync(user, Role.User.ToString());
                    if (!roleResult.Succeeded)
                        throw new SmartException(string.Join(Environment.NewLine, roleResult.Errors));

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
