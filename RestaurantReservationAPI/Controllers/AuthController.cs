using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestaurantReservationAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token.
        /// </summary>
        /// <param name="userLogin">The user login details.</param>
        /// <returns>A JWT token if authentication is successful.</returns>
        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] UserLogin userLogin)
        {
            if (userLogin == null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(
                Convert.FromBase64String(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("sub", "1")
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
               .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        /// <summary>
        /// Represents the user login details.
        /// </summary>
        public class UserLogin
        {
            /// <summary>
            /// Gets or sets the username.
            /// </summary>
            public string Username { get; set; }

            /// <summary>
            /// Gets or sets the password.
            /// </summary>
            public string Password { get; set; }
        }
    }
}