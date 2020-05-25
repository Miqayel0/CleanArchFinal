namespace CleanArch.Application.Common.Interfaces
{
    public interface IPaging
    {
        public int Count { get; set; }
        public int Page { get; set; }
    }
}
