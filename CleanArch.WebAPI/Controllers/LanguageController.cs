using CleanArch.Application.Languages.Commands.Create;
using CleanArch.Application.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    public class LanguageController : BaseController
    {

        [Authorize(Policy = Permission.Languages.Create)]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateLanguageCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
