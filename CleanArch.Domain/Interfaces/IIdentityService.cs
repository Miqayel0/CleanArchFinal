namespace CleanArch.Domain.Interfaces
{
    public interface IIdentityService
    {
        string UserIdentity { get; }

        string UserName { get; }

        string Language { get; }
    }
}
