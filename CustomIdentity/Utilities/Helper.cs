using CustomIdentity.Models;
using CustomIdentity.Models.PermissionModel;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Security.Claims;

namespace CustomIdentity.Utilities
{
    public static class Helper
    {
        public static Dictionary<string, string> PolicyClaimValueMap = new Dictionary<string, string>
        {
            { "ViewRights", Permissions.Products.View },
            { "DeleteRights", Permissions.Products.Delete},
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
public static string Admin = "Admin";
public static string SuperAdmin = "SuperAdmin";
public static string Operator = "Operator";
public static string User = "User";

//Response Messages

//Status Code 
public static int success_code = 1;
public static int failure_code = 0;


public static List<string> GeneratePermissionsForModule(string module)
{
    return new List<string>()
                {
                    $"Permissions.{module}.Create",
                    $"Permissions.{module}.View",
                    $"Permissions.{module}.Edit",
                    $"Permissions.{module}.Delete",
                };
}

public static void GetPermissions(this List<RoleClaimsViewModel> allPermissions, Type policy, string roleId)
{
    FieldInfo[] fields = policy.GetFields(BindingFlags.Static | BindingFlags.Public);
    foreach (FieldInfo fi in fields)
    {
        allPermissions.Add(new RoleClaimsViewModel { Value = fi.GetValue(null).ToString(), Type = "Permissions" });
    }
}
public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string permission)
{
    var allClaims = await roleManager.GetClaimsAsync(role);
    if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
    {
        await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
    }
}
    }
}
