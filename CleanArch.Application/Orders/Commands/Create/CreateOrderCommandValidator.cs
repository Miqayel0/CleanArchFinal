using FluentValidation;

namespace CleanArch.Application.Orders.Queries.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.ZipCode).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.BasketItems).NotEmpty();
        }
    }
}
