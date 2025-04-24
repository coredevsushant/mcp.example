using Microsoft.AspNetCore.Mvc;

namespace MCP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<WeatherForecast> Forecasts = new();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            // Pre-populate data if empty
            if (!Forecasts.Any())
            {
                Forecasts.AddRange(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }));
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            return Ok(Forecasts);
        }

        [HttpPost]
        public ActionResult<WeatherForecast> Post([FromBody] WeatherForecast newForecast)
        {
            Forecasts.Add(newForecast);
            return CreatedAtAction(nameof(Get), new { }, newForecast);
        }

        [HttpPut("{index}")]
        public IActionResult Put(int index, [FromBody] WeatherForecast updatedForecast)
        {
            if (index < 0 || index >= Forecasts.Count)
            {
                return NotFound($"No forecast at index {index}");
            }

            Forecasts[index] = updatedForecast;
            return NoContent();
        }
    }
}
