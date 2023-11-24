using Microsoft.AspNetCore.Identity;

namespace CustomIdentity.Models.ViewModels
{
    public class RoleVM
    {
        public IdentityRole Role { get; set; }
        public int UserCount { get; set; }
    }
}
