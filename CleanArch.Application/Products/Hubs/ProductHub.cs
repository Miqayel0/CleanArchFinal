using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CleanArch.Application.Products.Hubs
{
    // [Authorize]
    public class ProductHub : Hub<IProductClient>
    {
    }
}
