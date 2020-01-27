namespace CleanArch.Application.Account.Commands.Login
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}
