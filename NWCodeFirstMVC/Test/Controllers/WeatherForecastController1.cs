using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController1 : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController1> _logger;

        public WeatherForecastController1(ILogger<WeatherForecastController1> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecas1t")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}