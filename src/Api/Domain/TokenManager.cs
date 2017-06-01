using System.Security.Claims;

namespace Api.Domain
{
    public interface TokenManager
    {
        string GenerateToken(string username, int expireMinutes = 20);
        ClaimsPrincipal GetPrincipal(string token);


    }
}