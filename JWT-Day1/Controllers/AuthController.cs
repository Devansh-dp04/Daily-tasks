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
            string token = CreateToken(request);
            Console.WriteLine(token);
            return Ok("Login successful");
        }

        [Authorize(Roles = "admin")]
        [HttpGet("AdminGet")]
        public IActionResult AdminGet()
        {            
            return Ok("You are in Admin dashboard");
        }
        [Authorize(Roles = "doctor,admin")]
        [HttpGet("DoctorGet")]
        public IActionResult DoctorGet()
        {
            
            return Ok("You are in doctor dashboard");
        }
        [Authorize(Roles = "patient,admin")]
        [HttpGet("PatientGet")]
        public IActionResult PatientGet()
        {            
            return Ok("You are in patient dashboard");
        }
        private string CreateToken(UserDto user) {
            
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToLower().Trim())
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
