using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service
{
    public class JwtService
    {
        public string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ijurkbdlhmklqacwqzdxmkkhvqowlyqa");
            var token = jwtTokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    // the JTI is used for our refresh token which we will be convering 
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            });
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }

        public string GetUsername(string token)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var d = jwtTokenHandler.ReadJwtToken(token);
            return d.Claims.SingleOrDefault(x => x.Type == "email")?.Value;
        }
    }
}
