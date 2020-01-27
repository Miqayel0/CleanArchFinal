using MediatR;

namespace CleanArch.Application.Account.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }
        public string DeviceToken { get; set; }
    }
}
