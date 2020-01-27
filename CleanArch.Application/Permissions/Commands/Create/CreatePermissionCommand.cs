using MediatR;

namespace CleanArch.Application.Permissions.Commands.Create
{
    public class CreatePermissionCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
