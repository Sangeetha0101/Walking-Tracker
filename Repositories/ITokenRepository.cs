using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;

namespace IndiaWalks.Repositories
{
    public interface ITokenRepository
    {
         string CreateJWTToken(IdentityUser user,List<string> roles);
    }
}
