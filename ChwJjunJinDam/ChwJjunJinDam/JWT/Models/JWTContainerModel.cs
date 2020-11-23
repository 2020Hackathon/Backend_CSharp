using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ChwJjunJinDam.JWT.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public string SecretKey { get; set; } = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha512; // SecurityAlgorithms.Sha512
        public int ExpireMinutes { get; set; } = 10880; // 7days
        public Claim[] Claims { get; set; }
    }
}
