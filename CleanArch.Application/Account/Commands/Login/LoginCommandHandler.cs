using CleanArch.Domain.Exeptions;
using CleanArch.Domain.Identity;
using CleanArch.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtFactory;

        public LoginCommandHandler(UserManager<ApplicationUser> userManager,
                                   IJwtService jwtFactory,
                                   SignInManager<ApplicationUser> signInManager,
                                   RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtFactory = jwtFactory;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Email);
            if (user == null)
                throw new SmartException("Invalid username or password");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
                throw new SmartException($"Invalid username or password");

            var roles = await _userManager.GetRolesAsync(user);
            var roleClims = await GetRoleClimes(roles);
            var token = await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName, roles, roleClims);

            return new LoginResponse
            {

                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                AccessToken = token
            };
        }

        private async Task<IEnumerable<string>> GetRoleClimes(IList<string> roles)
        {
            IEnumerable<Claim> claims = new List<Claim>();
            var userRoles = await _roleManager.Roles
                .Where(x => roles.Contains(x.Name))
                .ToListAsync();

            foreach (var role in userRoles)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                if (roleClaims != null && roleClaims.Any())
                {
                    claims = claims.Concat(roleClaims);
                }
            }

            return claims.Select(x => x.Value);
        }
    }
}
