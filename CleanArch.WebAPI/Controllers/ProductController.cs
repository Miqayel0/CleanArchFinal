using CleanArch.Application.Permissions;
using CleanArch.Application.Products.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    //[Authorize(Policy = nameof(AppPermission.CanCreate))]
    public class ProductController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateProductCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
