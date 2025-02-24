using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
namespace Dot_NETDAY4.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public readonly ISavingTo _savingTo;    
    public readonly IReadFrom _readFrom;
    public WeatherForecastController(ISavingTo savingTo, IReadFrom readFrom)
    {
        _savingTo = savingTo;
        _readFrom = readFrom;
    }

    [HttpPost("employees")]
    public IActionResult PostRequest([FromBody] Employee employee)
    {
        try {
            _savingTo.SaveToTXT(employee);
            return Ok("Employee added successfully");
        }
        catch (Exception)
        {
            return BadRequest("Employee not added");
        }
        
    }

    [HttpGet("employees")]
    public IActionResult GetRequest([FromQuery] int id)
    {
        try { 

            var data = _readFrom.ReadFromTXT(id);            
            return Ok(data);
        }
        catch (Exception)
        {
            return BadRequest("Employee not found");
        }
    }
}
