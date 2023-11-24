using CustomIdentity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CustomIdentity.Repository
{
    public class PolicyService : IPolicyService
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public PolicyService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Claim>> GetRoleClaimsAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return Enumerable.Empty<Claim>();
            }

            var roleClaims = await _roleManager.GetClaimsAsync(role);
            return roleClaims;
        }

        public async Task<IEnumerable<Claim>> GetUserRoleClaimsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return Enumerable.Empty<Claim>();
            }

            var roleClaims = new List<Claim>();

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var claims = await _roleManager.GetClaimsAsync(role);
                    roleClaims.AddRange(claims);
                }
            }

            return roleClaims;
        }

        public async Task<bool> IsSuperAdmin(string? userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                return await _userManager.IsInRoleAsync(user, "SuperAdmin");
            }

            // Handle the case where the user with the given ID doesn't exist
            return false;
        }
    }
}
