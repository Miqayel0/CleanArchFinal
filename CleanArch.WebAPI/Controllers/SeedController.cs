using CleanArch.Application.Categories.Commands.Create;
using CleanArch.Application.SeedData.Command;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    public class SeedController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Seed()
        {
            return Ok(await Mediator.Send(new SeedDataCommand()));
        }
    }
}
