using CleanArch.Application.Roles.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    public class RoleController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateRoleCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
