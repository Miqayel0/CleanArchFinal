using CleanArch.Application.Languages.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    //[Authorize(Policy = nameof(AppPermission.CanCreate))]
    public class LanguageController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateLanguageCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
