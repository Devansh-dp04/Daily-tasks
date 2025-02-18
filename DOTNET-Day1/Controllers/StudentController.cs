using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DOTNET_Day1.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{   
    string path = @"D:\BacancyInternship (2)\DOTNET-Day1\Data.txt";
    [HttpPost("PostRequest")]    
    public async Task<IActionResult> WriteData(Student student) {
        try
        {
            string data = JsonConvert.SerializeObject(student);
            await System.IO.File.AppendAllTextAsync(path, data);
            return Ok("Written in the file");
        }
        catch (Exception)
        {
            return StatusCode(500, "Data not appended successfully");
        }
    }
    
}
