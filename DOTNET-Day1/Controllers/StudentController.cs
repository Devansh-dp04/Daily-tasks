using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace DOTNET_Day1.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{   
    private readonly ISavingTo _isavingto;
    private readonly IReadFrom _ireadfrom;
    public StudentController(ISavingTo _isavingTo, IReadFrom _ireadFrom)
    {
        _isavingto= _isavingTo;
        _ireadfrom = _ireadFrom;
    }   
    [HttpPost("PostRequest")]    
    public async Task<IActionResult> WriteData(Student student) {
		try
        {
            _isavingto.SaveToTXT(student);            
            return Ok("Data appended successfully");
        }
		catch (Exception)
		{
            return StatusCode(500, "Data not appended successfully");            
		}

    }

    [HttpGet("GetRequest")]
    public async Task<IActionResult> ReadData()
    {
        try
        {
            Student student = _ireadfrom.ReadFromTXT();
            return Ok(student);
        }
        catch (Exception)
        {
            return StatusCode(500, "Data cannot be read.");
        }

    }

}
