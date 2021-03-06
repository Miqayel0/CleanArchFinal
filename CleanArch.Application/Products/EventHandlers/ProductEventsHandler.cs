﻿using CleanArch.Application.Products.Hubs;
using CleanArch.Application.Roles;
using CleanArch.Domain.Events;
using CleanArch.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.EventHandlers
{
    public class ProductEventsHandler : INotificationHandler<ProductDiscountedDomainEvent>
    {
        private readonly IHubContext<ProductHub, IProductClient> _hubContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductEventsHandler(IHubContext<ProductHub, IProductClient> hubContext, UserManager<ApplicationUser> userManager)
        {
            _hubContext = hubContext;
            _userManager = userManager;
        }

        public async Task Handle(ProductDiscountedDomainEvent notification, CancellationToken cancellationToken)
        {
            var users = await _userManager.GetUsersInRoleAsync(Role.User.ToString());
            var userIds = users.Select(x => x.Id).ToList();
            await _hubContext.Clients.Users(userIds).ProductDiscounted(new
            {
                ProductId = notification.DiscountedProduct.Id,
                Price = notification.DiscountedProduct.UnitPrice
            });
        }
    }
}
