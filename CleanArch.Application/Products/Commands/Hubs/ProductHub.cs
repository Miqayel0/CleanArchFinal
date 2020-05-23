using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CleanArch.Application.Products.Commands.Hubs
{
    // [Authorize]
    public class ProductHub : Hub<IProductClient>
    {
    }
}
