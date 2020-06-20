using FluentValidation;

namespace CleanArch.Application.Orders.Queries.GetOrdersWeb
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
        }
    }
}
