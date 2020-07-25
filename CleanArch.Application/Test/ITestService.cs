using System.Threading.Tasks;

namespace CleanArch.Application.Test
{
    public interface ITestService
    {
        int TestMethod();
        Task<int> TestMethod2();
    }
}
