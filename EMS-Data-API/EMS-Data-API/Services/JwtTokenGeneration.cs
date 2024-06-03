using EMS_Data_API.Models;
using EMS_Data_API.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EMS_Data_API.Services
{
    public class JwtTokenGeneration : IJwtTokenGeneratorRepo
    {
        private readonly JwtOptions jwtOptions;
        public JwtTokenGeneration(IOptions<JwtOptions> options)
        {
            jwtOptions= options.Value;
        }
        public  string GenerateToken(ApplicationUser user, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key=Encoding.ASCII.GetBytes(jwtOptions.Secret);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                new Claim(JwtRegisteredClaimNames.Name,user.FullName)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Audience = jwtOptions.Audience,
                Issuer = jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token=tokenHandler.CreateToken(tokendescriptor);
            return tokenHandler.WriteToken(token);


        }
    }
}
