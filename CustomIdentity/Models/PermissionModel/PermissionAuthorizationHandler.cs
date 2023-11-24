using CustomIdentity.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CustomIdentity.Models.PermissionModel
{
    internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirements>
    {
        private readonly IPolicyService _policyService;

        public PermissionAuthorizationHandler(IPolicyService policyService)
        {
            _policyService = policyService;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirements requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                return;
            }

            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isSuperAdmin = await _policyService.IsSuperAdmin(userId);

            if (isSuperAdmin)
            {
                context.Succeed(requirement);
                return;
            }

            var roleClaims = await _policyService.GetUserRoleClaimsAsync(userId);

            if (roleClaims.Any(claim => claim.Value == requirement.Permission))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
