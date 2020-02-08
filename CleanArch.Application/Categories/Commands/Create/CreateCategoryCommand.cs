using MediatR;

namespace CleanArch.Application.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
