using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecureJwtApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecureJwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //
        // LOGIN API
        //
        [HttpPost("login")]
        public IActionResult Login(LoginModel login)
        {
            // Sample hardcoded users

            if (login.Username == "admin"
                && login.Password == "Admin@123")
            {
                var token = GenerateJwtToken(
                    login.Username,
                    "Admin");

                return Ok(new
                {
                    token = token
                });
            }

            if (login.Username == "user"
                && login.Password == "User@123")
            {
                var token = GenerateJwtToken(
                    login.Username,
                    "User");

                return Ok(new
                {
                    token = token
                });
            }

            return Unauthorized();
        }

        //
        // GENERATE JWT TOKEN
        //
        private string GenerateJwtToken(
            string username,
            string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,
                    username),

                new Claim(ClaimTypes.Role,
                    role),

                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            };

            var key =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        _configuration["Jwt:Key"]));

            var signIn =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            var token =
                new JwtSecurityToken(
                    issuer:
                        _configuration["Jwt:Issuer"],

                    audience:
                        _configuration["Jwt:Audience"],

                    claims: claims,

                    expires:
                        DateTime.UtcNow.AddMinutes(15),

                    signingCredentials: signIn);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}