using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.Users.Commands.AddRole
{
    public class AddRoleToUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
