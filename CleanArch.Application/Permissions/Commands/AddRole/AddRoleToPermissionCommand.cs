using MediatR;
using System.Collections.Generic;

namespace CleanArch.Application.Permissions.Commands.AddRole
{
    public class AddRoleToPermissionCommand : IRequest<bool>
    {
        public long PermissionId { get; set; }
        public List<string> RoleIds { get; set; }
    }
}
