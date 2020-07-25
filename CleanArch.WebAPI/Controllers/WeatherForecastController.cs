using CleanArch.Application.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ITestService _testService;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet]
        public ActionResult<int> AsyncTest()
        {
            _logger.LogInformation("******************");
            _logger.LogInformation($"Start Controller Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            var pp = _testService.TestMethod();
            _logger.LogInformation($"End Controller Thread Id: {Thread.CurrentThread.ManagedThreadId} {pp}");

            return Ok(pp);
        }

        [HttpGet]
        public async Task<ActionResult<int>> AsyncTest2()
        {
            _logger.LogInformation("******************");
            _logger.LogInformation($"Start Controller Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            var pp = await _testService.TestMethod2();
            _logger.LogInformation($"End Controller Thread Id: {Thread.CurrentThread.ManagedThreadId} {pp}");

            return Ok(pp);
        }
    }
}
