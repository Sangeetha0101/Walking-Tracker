using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IndiaWalks.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateJWTToken(IdentityUser user, List<string> roles)
        {
            //create claims
            var claims = new List<Claim>();
            {
               claims.Add( new Claim(ClaimTypes.Email, user.Email));
                //new Claim(ClaimTypes.NameIdentifier, user.Id);
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Token expiration configurable through appsettings
            var tokenExpirationMinutes = int.Parse(configuration["Jwt:TokenExpirationMinutes"] ?? "15");

            var token = new JwtSecurityToken
                (
                 configuration["Jwt:Issuer"],
                  configuration["Jwt:Audience"],
                 claims,
                 expires:DateTime.Now.AddMinutes(tokenExpirationMinutes),
                 signingCredentials: credentials
                 );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
