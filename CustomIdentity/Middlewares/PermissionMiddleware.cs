using CustomIdentity.Models;
using CustomIdentity.Models.PermissionModel;
using CustomIdentity.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

public class PermissionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Dictionary<string, string> policyClaimValueMap;
    public PermissionMiddleware(RequestDelegate next)
    {
        _next = next;
        policyClaimValueMap = new Dictionary<string, string>
        {
            { "ViewRights", Permissions.Products.View},
            { "DeleteRights", Permissions.Products.Delete },
            { "CreateRights", Permissions.Products.Create },
            { "EditRights", Permissions.Products.Edit },
            { "ViewUserRights", Permissions.Account.View },
            { "DeleteUserRights", Permissions.Account.Delete },
            { "CreateUserRights", Permissions.Account.Create },
            { "EditUserRights", Permissions.Account.Edit },
            { "ViewCategoryRights", Permissions.Category.View },
            { "DeleteCategoryRights", Permissions.Category.Delete },
            { "CreateCategoryRights", Permissions.Category.Create },
            { "EditCategoryRights", Permissions.Category.Edit },
            { "ViewsubCategoryRights", Permissions.SubCategory.View },
            { "DeletesubCategoryRights", Permissions.SubCategory.Delete },
            { "CreatesubCategoryRights", Permissions.SubCategory.Create },
            { "EditsubCategoryRights", Permissions.SubCategory.Edit }
        };
    }
    public async Task Invoke(HttpContext context, IAuthorizationService _authorizationService,
        IPolicyService _policyService)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isSuperAdmin = await _policyService.IsSuperAdmin(userId);
            var endpoint = context.GetEndpoint();
            var authorizeData = endpoint?.Metadata.GetOrderedMetadata<IAuthorizeData>();
            
            if (endpoint == null)
            {
                await _next(context);
                return;
            }
            if (isSuperAdmin)
            {
                await _next(context);
                return;
            }
            
            if (authorizeData?.Count() > 0)
            {
                foreach (var authorizeAttribute in authorizeData)
                {
                    var policy = authorizeAttribute.Policy;
                    if (authorizeAttribute.Policy != null && policyClaimValueMap.TryGetValue(authorizeAttribute.Policy, out var claimValue))
                    {
                        var permissionRequirement = new PermissionRequirements(policy);

                        var authorizationResult = await _authorizationService.AuthorizeAsync(context.User, null, claimValue);

                        if (!authorizationResult.Succeeded)
                        {
                            var baseUrl = $"{context.Request.Scheme}://{context.Request.Host}";
                            context.Response.Redirect($"{baseUrl}/Account/AccessDenied");
                            return;
                        }
                        await _next(context);
                        return;
                    }
                    else
                    {
                        await _next(context);
                        return;
                    }
                }
            }
        }

        await _next(context);
    }
}