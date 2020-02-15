using FluentValidation;

namespace CleanArch.Application.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEmpty();
        }
    }
}
