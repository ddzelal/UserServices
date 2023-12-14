using System.Security.Claims;
using UserRepository.Interfaces;

namespace UserRepository.Helper
{
    public class GetClaim : IGetClaim
    {
        public int GetUserIdFromClaims(ClaimsPrincipal claims) => Convert.ToInt16(claims.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault());
    }
}