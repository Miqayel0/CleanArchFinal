using CleanArch.Application.Categories.Commands.Create;
using CleanArch.Application.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    //[Authorize(Policy = nameof(AppPermission.CanCreate))]
    public class CategoryController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateCategoryCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
