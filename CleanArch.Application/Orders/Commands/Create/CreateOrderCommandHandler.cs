using Ardalis.GuardClauses;
using CleanArch.Domain.Entities.OrderAggregation;
using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Orders.Queries.Create
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

            var shippingAddress = new Address(request.Street, request.City, request.State, request.Country, request.ZipCode);
            var order = new Order(_identityService.UserIdentity, shippingAddress, request.FinishDt, OrderStatus.Pending, 500);

            foreach (var item in request.BasketItems)
            {
                var product = await _repository.GetByIdAsync<Product>(item.ProductId);
                Guard.Against.Null(product, nameof(Product));

                order.AddOrderItem(product.UnitPrice, item.Units, item.ProductId);
            }

            await _repository.Create(order);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
