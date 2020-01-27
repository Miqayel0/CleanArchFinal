using MediatR;

namespace CleanArch.Application.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
