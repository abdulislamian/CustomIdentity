using CustomIdentity.Models.PermissionModel;
using CustomIdentity.Models;
using Microsoft.AspNetCore.Authorization;

namespace CustomIdentity.Utilities
{
    public static class AuthorizationPolicies
    {
        public static void ConfigurePolicies(AuthorizationOptions options)
        {
            options.AddPolicy("FullAdminAccess", policy => policy.RequireRole(CustomIdentity.Utilities.Helper.SuperAdmin));
            
            options.AddPolicy("FullProductAccess", policy =>
            policy.RequireAssertion(context=>
            context.User.IsInRole(Helper.Admin) && 
            context.User.HasClaim(claims=> claims.Type == CustomClaimTypes.Permission && claims.Value== Permissions.Products.View) ||
            context.User.IsInRole(Helper.SuperAdmin)
            ));

            options.AddPolicy("ViewRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Products.View); });
            options.AddPolicy("DeleteRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Products.Delete); });
            options.AddPolicy("CreateRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Products.Create); });
            options.AddPolicy("EditRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Products.Edit); });

            options.AddPolicy("ViewUserRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Account.View); });
            options.AddPolicy("DeleteUserRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Account.Delete); });
            options.AddPolicy("CreateUserRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Account.Create); });
            options.AddPolicy("EditUserRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Account.Edit); });

            options.AddPolicy("ViewCategoryRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Category.View); });
            options.AddPolicy("DeleteCategoryRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Category.Delete); });
            options.AddPolicy("CreateCategoryRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Category.Create); });
            options.AddPolicy("EditCategoryRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Category.Edit); });

            options.AddPolicy("ViewsubCategoryRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.SubCategory.View); });
            options.AddPolicy("DeletesubCategoryRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.SubCategory.Delete); });
            options.AddPolicy("CreatesubCategoryRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.SubCategory.Create); });
            options.AddPolicy("EditsubCategoryRights", policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.SubCategory.Edit); });


            options.InvokeHandlersAfterFailure = false;
            }
    }

}
