using CleanArch.Application.Permissions;
using CleanArch.Application.Products.Commands.Create;
using CleanArch.Application.Products.Queries.GetAllProductsWeb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    public class ProductController : BaseController
    {
        [Authorize(Policy = Permission.Products.Create)]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateProductCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize(Policy = Permission.Products.View)]
        [HttpGet]
        public async Task<ActionResult<GetAllProductsListModelWeb>> GetAllProductsWeb([FromQuery] GetAllProductsWebQuery request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
