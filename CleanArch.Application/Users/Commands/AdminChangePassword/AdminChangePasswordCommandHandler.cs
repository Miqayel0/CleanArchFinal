using CleanArch.Domain.Exeptions;
using CleanArch.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Users.Commands.ChangePassword
{
    public class AdminChangePasswordCommandHandler : IRequestHandler<AdminChangePasswordCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminChangePasswordCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(AdminChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Email);
            if (user == null)
                throw new SmartException("User not found");
            if (!IsValidPassword(request.NewPassword))
                throw new SmartException("Incorrect format of Password");

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, request.NewPassword);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                throw new SmartException(string.Join(Environment.NewLine, result.Errors));

            return true;
        }

        public bool IsValidPassword(string input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            return hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
        }
    }
}
