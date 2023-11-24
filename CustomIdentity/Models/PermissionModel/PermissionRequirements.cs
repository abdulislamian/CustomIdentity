using Microsoft.AspNetCore.Authorization;

namespace CustomIdentity.Models.PermissionModel
{
    internal class PermissionRequirements:IAuthorizationRequirement
    {
        public string Permission { get; private set; }
        public PermissionRequirements(string permission)
        {
            Permission = permission;
        }
    }
}
