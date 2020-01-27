using CleanArch.Domain.Exeptions;
using CleanArch.Domain.Identity;
using CleanArch.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtFactory;

        public LoginCommandHandler(UserManager<ApplicationUser> userManager, IJwtService jwtFactory, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtFactory = jwtFactory;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {        
            var user = await _userManager.FindByNameAsync(request.Email);
            if (user == null)
                throw new SmartException("Invalid username or password");
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                throw new SmartException($"Invalid username or password");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName, roles);

            return new LoginResponse
            {

                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                AccessToken = token
            };
        }
    }
}
