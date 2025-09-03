using Microsoft.AspNetCore.Mvc;
using NLogApp.Entities;

namespace NLogApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public Task<IActionResult> Get()
    {
        _logger.LogInformation("Example log using Nlog");

        WeatherForecast[] weatherForecasts = Enumerable.Range(1, 5).Select
            (index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }
            )
            .ToArray();
        

        return Task.FromResult<IActionResult>(Ok(weatherForecasts));
    }
}