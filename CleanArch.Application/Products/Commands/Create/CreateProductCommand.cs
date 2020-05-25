using MediatR;
using System.Collections.Generic;

namespace CleanArch.Application.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUri { get; set; }
        public decimal UnitPrice { get; set; }
        public long CategoryId { get; set; }

        public List<CreateProductTranslationDto> Translations { get; set; }
        public decimal DiscountedPrice { get; internal set; }
    }

    public class CreateProductTranslationDto
    {
        public string PropertyKey { get; set; }
        public string PropertyValue { get; set; }
        public long LanguageId { get; set; }
    }
}
