using Microsoft.AspNetCore.Mvc;

namespace MovieFinder.Api.Client.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<SessionController> _logger;

    public SessionController(ILogger<SessionController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "Create")]
    public IEnumerable<WeatherForecast> Create()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

