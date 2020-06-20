using Ardalis.GuardClauses;
using CleanArch.Domain.Entities.OrderAggregation;
using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Orders.Queries.GetOrdersWeb
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IRepository _repository;
        private readonly IIdentityService _identityService;
        public CreateOrderCommandHandler(IRepository repository, IIdentityService identityService)
        {
            _repository = repository;
            _identityService = identityService;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Guard.Against.NullOrEmpty(_identityService.UserIdentity, "UserId");

            var items = new List<OrderItem>();
            var shippingAddress = new Address(request.Street, request.City, request.State, request.Country, request.ZipCode);

            foreach (var item in request.BasketItems)
            {
                var product = await _repository.GetByIdAsync<Product>(item.ProductId);
                Guard.Against.NegativeOrZero(item.ProductId, nameof(item.ProductId));
                Guard.Against.NegativeOrZero(item.Units, nameof(item.Units));
                Guard.Against.Null(product, nameof(Product));

                items.Add(new OrderItem(product.UnitPrice, item.Units, item.ProductId));
            }

            var order = new Order(_identityService.UserIdentity, shippingAddress, items, request.FinishDt,OrderStatus.Pending, 500);

            await _repository.Create(order);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
