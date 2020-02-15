using MediatR;

namespace CleanArch.Application.Languages.Commands.Create
{
    public class CreateLanguageCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
