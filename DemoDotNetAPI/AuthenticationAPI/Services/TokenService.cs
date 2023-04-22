using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public ResponseTokenModel RequestToken(RequestAuthenModel model)
        {
            try
            {
                if (model.username != "demotest" || model.password != "aa112233")
                {
                    throw new ValidationException("Invalid data.");
                }

                RequestTokenModel data = new RequestTokenModel
                {
                    customerId = "10009999",
                    customerStatus = "N",
                    username = "DemoTest01"
                };

                var token = GenerateJwtToken(data);

                return new ResponseTokenModel 
                {
                    status = 200,
                    success = true,
                    data = token
                };
            }
            catch (Exception ex)
            {
                return new ResponseTokenModel
                {
                    status = 500,
                    success = false,
                    message = "RequestToken failed. Please enter a valid data.",
                    error = ex.Message
                };
            }
        }

        public string GenerateJwtToken(RequestTokenModel model)
        {
            var issuer = _configuration["JWT:issuer"];
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:securityKey"]);
            var expiresMinutes = Convert.ToInt32(_configuration["JWT:expiresMinutes"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.UserData, model.username),
                    new Claim(ClaimTypes.PrimarySid, model.customerId),
                    new Claim(ClaimTypes.Role, model.customerStatus),
                    new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.Now.Subtract(TimeSpan.FromMinutes(-expiresMinutes)),
                Issuer = issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
