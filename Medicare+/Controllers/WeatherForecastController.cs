using Microsoft.AspNetCore.Mvc;

namespace Medicare_.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    { 
        
           
    }
}
