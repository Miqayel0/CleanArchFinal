using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Test
{
    public class TestService : ITestService
    {
        private readonly ILogger<TestService> _logger;
        private static int counter = 0;

        public TestService(ILogger<TestService> logger)
        {
            _logger = logger;
        }

        public int TestMethod()
        {
            counter++;
            int pp = 0;
            _logger.LogInformation($"Start Test Method {counter}, Thread Id = {Thread.CurrentThread.ManagedThreadId}");
            if (counter == 1)
            {
                pp =  Sleep1();
            }

            _logger.LogInformation($"End Test Method {counter} Thread Id = {Thread.CurrentThread.ManagedThreadId}");
            return pp;
        }

        public int Sleep1()
        {
            Thread.Sleep(20000);
            return 20000;
        }



        public async Task<int> TestMethod2()
        {
            counter++;
            int pp = 0;
            _logger.LogInformation($"Start Test Method {counter}, Thread Id = {Thread.CurrentThread.ManagedThreadId}");
            if (counter == 1)
            {
               await Task.Delay(20000);
                pp = 20000;
            }

            _logger.LogInformation($"End Test Method {counter} Thread Id = {Thread.CurrentThread.ManagedThreadId}");
            return pp;
        }
    }
}
