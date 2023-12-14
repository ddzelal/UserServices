using System.Security.Claims;

namespace UserRepository.Interfaces
{
    public interface IGetClaim
    {
        int GetUserIdFromClaims(ClaimsPrincipal claims);

    }
}