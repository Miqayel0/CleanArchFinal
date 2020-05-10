using CleanArch.Application.Permissions;
using CleanArch.Application.Roles.Commands.AddClaimToRole;
using CleanArch.Application.Roles.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    //[Authorize(Policy = nameof(AppPermission.CanCreate))]
    public class RoleController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateRoleCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> AddClaimToRole([FromBody] AddClaimToRoleCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
