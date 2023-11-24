using System.Security.Claims;

namespace CustomIdentity.Repository
{
    public interface IPolicyService
    {
        Task<IEnumerable<Claim>> GetRoleClaimsAsync(string roleId);
        Task<IEnumerable<Claim>> GetUserRoleClaimsAsync(string userId);
        Task<bool> IsSuperAdmin(string? userId);
    }
}
