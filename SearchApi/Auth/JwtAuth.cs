using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace SearchApi.Auth
{
    public class JwtAuth
    {
        public static string GenerateJwtToken(string username, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username)
            };

            roles.ForEach(role => { claims.Add(new Claim(ClaimTypes.Role, role)); });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["config:JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(Convert.ToString(ConfigurationManager.AppSettings["config:JwtExpireDays"])));
            var token = new JwtSecurityToken("Issuer", "Audience", claims, null, expires, creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool ValidateToken(string token)
        {
            if (token == null) return false;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Convert.ToString(ConfigurationManager.AppSettings["config:JwtKey"]));
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

                var jwtToken = (JwtSecurityToken)validatedToken;
                var jti = jwtToken.Claims.First(claim => claim.Type == "jti").Value;
                var userName = jwtToken.Claims.First(sub => sub.Type == "sub").Value;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}