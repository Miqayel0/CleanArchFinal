using MediatR;
using System.Collections.Generic;

namespace CleanArch.Application.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public List<CreateCategoryTranslationDto> Translations { get; set; }
    }

    public class CreateCategoryTranslationDto
    {
        public string PropertyKey { get; set; }
        public string PropertyValue { get; set; }
        public long LanguageId { get; set; }
    }
}
