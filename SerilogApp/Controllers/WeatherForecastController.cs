using Microsoft.AspNetCore.Mvc;
using Serilog;
using SerilogApp.Entities;

namespace SerilogApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        // Using a static method from Serilog, no need to inject.
        Log.Information("Method Get() has been executed.");

        var result = Enumerable.Range(1, 5).Select
            (index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }
            )
            .ToArray();

        // Using serializtion.
        Log.Information("Results are {@result}", result);

        return result;
    }
}