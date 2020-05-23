using CleanArch.Application.Products.Commands.Events;
using CleanArch.Application.Products.Commands.Hubs;
using CleanArch.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.EventHandlers
{
    public class ProductEventsHandler : INotificationHandler<ProductDiscountedEvent>
    {
        private readonly IHubContext<ProductHub, IProductClient> _hubContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public Task Handle(ProductDiscountedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
