using CleanArch.Application.Account.Commands.Login;
using CleanArch.Application.Account.Commands.Register;
using CleanArch.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signinManager, UserManager<ApplicationUser> userManager)
        {
            _signinManager = signinManager;
            _userManager = userManager;
        }


        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Register([FromBody] RegisterCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        //[HttpPost]
        //public async Task<ActionResult> ExternalLogin(string provider, string returnUrl)
        //{
        //    var returUri = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
        //    var properties = _signinManager.ConfigureExternalAuthenticationProperties(provider, returnUrl);
        //    return Challenge(properties, provider);
        //}

        //public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        //{
        //    var info = await _signinManager.GetExternalLoginInfoAsync();
        //    var signin = await _signinManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
        //    var user = new ApplicationUser { UserName = info.Principal.FindFirst(ClaimTypes.Name.Replace(" ", "_")).Value };
        //    var userResult = await _userManager.CreateAsync(user);
        //    await _userManager.AddLoginAsync(user, info);
        //    return null;
        //}
    }
}
