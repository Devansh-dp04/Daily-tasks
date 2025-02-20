using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DOT_NETDay3.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IGUID1 _guid1;
    private readonly IGUID2 _guid2;
    private readonly IGUID2 _guid4;
    private readonly IGUID3 _guid3;
    private readonly IGUID3 _guid5;
    public WeatherForecastController(IGUID1 gUID1, IGUID2 gUID2, IGUID2 guid4, IGUID3 gUID3, IGUID3 gUID31)
    {
        _guid1 = gUID1;
        _guid2 = gUID2;
        _guid3 = gUID3;
        _guid4 = guid4;
        _guid5 = gUID31;
    }
    [HttpGet("GetRequest")]
    public IActionResult Get()
    {
        Console.WriteLine($"Singleton: {_guid1.Getguid1()}");        
        Console.WriteLine($"Transient: {_guid3.Getguid1()}");
        Console.WriteLine($"Transient: {_guid5.Getguid1()}");
        Console.WriteLine($"Scoped: {_guid2.Getguid1()}");
        Console.WriteLine($"Scoped: {_guid4.Getguid1()}");
        return Ok();
    }
}
