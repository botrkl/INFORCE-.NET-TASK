using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using URLShortener.BLL.Models;
using URLShortener.BLL.Services.Intefaces;

namespace URLShortener.BLL.Services.Classes
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserModel userModel)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userModel.Username),
                new Claim("UserId", userModel.Id.ToString()),
                new Claim("IsAdmin", userModel.IsAdmin.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Guid GetUserIdFromJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                if (validatedToken is JwtSecurityToken jwtToken)
                {
                    var userIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "UserId");

                    if (userIdClaim != null)
                    {
                        return Guid.Parse(userIdClaim.Value);
                    }
                }

                throw new ArgumentException("Invalid token: UserId claim is missing or invalid");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Token validation failed: " + ex.Message);
            }
        }
        public bool CheckUserIsAdmin(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                if (validatedToken is JwtSecurityToken jwtToken)
                {
                    var isAdminClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "IsAdmin");

                    if (isAdminClaim != null && bool.TryParse(isAdminClaim.Value, out bool isAdmin))
                    {
                        return isAdmin;
                    }
                }

                throw new ArgumentException("Invalid token: IsAdmin claim is missing or invalid");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Token validation failed: " + ex.Message);
            }
        }
    }
}
