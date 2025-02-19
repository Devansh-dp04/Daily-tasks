using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day2.Controllers;

[ApiController]
[Route("[controller]")]
public class MiddlewareController : ControllerBase
{      
    [HttpGet("GetRequest")]
    public IActionResult GetRequest()
    {
        DateTime time = DateTime.Now;        
        return Ok($"Request responed at {time}"); 
    }
}
