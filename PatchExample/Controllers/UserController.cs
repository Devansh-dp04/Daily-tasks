using Microsoft.AspNetCore.Mvc;
using PatchExample.UserDto;
using PatchExample.User;
namespace PatchExample.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost("PostData")]
    public IActionResult PostData(UserMain user)
    {
        var userList = UserMain.userlist;
        userList.Add(user);
        return Ok(user);
    }

    [HttpPatch("PatchTemprature")]
    public IActionResult PatchRequest(UserUpdateDto request)
    {
        var UserUpdate = UserMain.userlist.FirstOrDefault(item => item.Id == request.Id);
        foreach (var prop in typeof(UserUpdateDto).GetProperties() )
        {
            var value = prop.GetValue(request);
            if (value != null)
            {
                var userproperty = typeof(UserMain).GetProperty(prop.Name);
                userproperty?.SetValue(UserUpdate, value);
            }
        }
        return Ok(UserUpdate);
    }
}
