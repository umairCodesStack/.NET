using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestfulService.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginViewModel userLogin)
        {
            // Simulate user authentication
            if (userLogin.Username == "admin" && userLogin.Password == "password")
            {
                var claims = new[]
                {
                   new Claim(ClaimTypes.Name, userLogin.Username),
                     new Claim(ClaimTypes.Role, "Admin")
               };
                var key=new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("YourSecretKey1234567890-1234-123321-123"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return Unauthorized();
        }
    }
}
