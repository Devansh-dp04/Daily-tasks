using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JWT_Day1.Entities;
using JWT_Day1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWT_Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        public static User user = new User();
        static List<User> userlist = new List<User>();
        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            var hashedpassword = new PasswordHasher<User>().HashPassword(user, request.Password);
            user.Username = request.Username;
            user.PasswordHash = hashedpassword;
            userlist.Add(user);
            return Ok(user);
        }
        [HttpPost("Login")]
        public ActionResult<string> Login(UserDto request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User Not found");
            }
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            {
                return BadRequest("Wrong Password");
            }
            string token = CreateToken(user);
            Console.WriteLine(token);
            return Ok("Login successful");
        }

        [Authorize]
        [HttpGet("GetRequest")]
        public IActionResult Get()
        {
            foreach (var usermember in userlist)
            {
                Console.WriteLine($"Name: {usermember.Username}\n,PasswordHash: {usermember.PasswordHash}");
            }
            return Ok("Get Request Successful");
        }
        private string CreateToken(User user) {
            
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetValue<string>("jwt:key")!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var tokendescriptor = new JwtSecurityToken(
                        issuer: configuration.GetValue<string>("jwt:issuer"),
                        audience: configuration.GetValue<string>("jwt:audience"),
                        expires: DateTime.Now.AddMinutes(30),
                        claims: claims,
                        signingCredentials: creds
                );           
                return new JwtSecurityTokenHandler().WriteToken(tokendescriptor);
            }


        
    }
    
    
}
