using CleanArch.Application.Permissions.Commands.AddRole;
using CleanArch.Application.Permissions.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    public class PermissionController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreatePermissionCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddRole([FromBody] AddRoleToPermissionCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}