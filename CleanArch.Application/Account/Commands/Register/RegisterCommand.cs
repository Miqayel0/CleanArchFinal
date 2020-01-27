using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.Account.Commands.Register
{
    public class RegisterCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
