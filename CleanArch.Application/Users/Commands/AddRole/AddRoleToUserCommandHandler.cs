using CleanArch.Domain.Exeptions;
using CleanArch.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Users.Commands.AddRole
{
    public class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AddRoleToUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Email);
            if (user == null)
                throw new SmartException("User not found");
            var result = await _userManager.AddToRoleAsync(user, request.Role);
            if (!result.Succeeded)
                throw new SmartException(string.Join(Environment.NewLine, result.Errors));

            return true;
        }
    }
}
