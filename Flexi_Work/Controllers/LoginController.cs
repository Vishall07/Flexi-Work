using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Flexi_Work.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            // Dummy username/password check
            if (user.Email != "vishal" || user.Password != "1234")
                return (IActionResult)Results.Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_super_secret_key_123!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "myapi",
                audience: "myusers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return (IActionResult)Results.Ok(new { token = tokenString });
        }

    }
}
