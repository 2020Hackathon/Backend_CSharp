using ChwJjunJinDam.JWT.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace ChwJjunJinDam.JWT.Services
{
    public interface IAuthService
    {
        string SecretKey { get; set; }
        bool IsTokenValid(string token);
        string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}

