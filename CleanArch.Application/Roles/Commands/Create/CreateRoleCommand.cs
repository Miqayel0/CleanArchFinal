using MediatR;

namespace CleanArch.Application.Roles.Commands.Create
{
    public class CreateRoleCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
