using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private static List<WeatherForecast> listWeather = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if(listWeather == null || !listWeather.Any())
        {
            listWeather = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("get/ListWeather")]
    [Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        return listWeather;
    }

    [HttpPost]
    [Route("post/weather")]
    public IActionResult Post(WeatherForecast weather)
    {
        listWeather.Add(weather);
        return Ok();
    }
    [HttpDelete("{index}")]
    [Route("delete/weather")]
    public IActionResult Delete(int index)
    {
        try
        {
            listWeather.RemoveAt(index);            
        }
        catch (ArgumentOutOfRangeException)
        {            
            return BadRequest(new { msg = $"Data doesn't exist at index: { index }"});
        }

        return Ok(new {msg = "Deleted!"});
    }
}
