using CustomIdentity.Models.PermissionModel;
using CustomIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CustomIdentity.Utilities;
using AspNetCoreHero.ToastNotification.Abstractions;
using CustomIdentity.Models.PermissionModel.ViewModel;
using NuGet.Packaging;

namespace CustomIdentity.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class PermissionController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly INotyfService _notyf;

        public PermissionController(RoleManager<IdentityRole> roleManager, INotyfService notyf)
        {
            _roleManager = roleManager;
            _notyf = notyf;
        }
        [HttpGet]
        public async Task<ActionResult> Index(string id)
        {
            string roleId = id;

            var model = new PermissionViewModel
            {
                RoleId = roleId,
                Categories = new List<PermissionCategoryViewModel>()
            };

            var allPermissions = new List<RoleClaimsViewModel>();
            allPermissions.GetPermissions(typeof(Permissions.Products), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Account), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Category), roleId);
            allPermissions.GetPermissions(typeof(Permissions.SubCategory), roleId);

            var role = await _roleManager.FindByIdAsync(roleId);
            model.RoleId = roleId;

            var claims = await _roleManager.GetClaimsAsync(role);
            var allClaimValues = allPermissions.Select(a => a.Value).ToList();
            var roleClaimValues = claims.Select(a => a.Value).ToList();
            var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();

            foreach (var permission in allPermissions)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }
            //var categoryGroup = allPermissions.GroupBy(a => a.Value).ToList();
            var groupedPermissions = allPermissions
           .GroupBy(p => GetModuleName(p.Value))
           .Select(group => new PermissionCategoryViewModel
           {
               CategoryName = group.Key,
               Permissions = group.Select(permission => new PermissionItemViewModel
               {
                   Type = permission.Type,
                   Value = permission.Value,
                   Selected = permission.Selected
               }).ToList()
           })
           .ToList();

            model.Categories.AddRange(groupedPermissions);

            return View(model);
        }
        private string GetModuleName(string value)
        {
            var parts = value.Split('.');
            if (parts.Length > 2)
            {
                return parts[1]; 
            }
            return value; 
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] PermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            foreach (var permission in model.Categories.SelectMany(category => category.Permissions).Where(a => a.Selected))
            {
                await _roleManager.AddPermissionClaim(role, permission.Value);
            }

            _notyf.Information("Permissions Updated Successfully", 3);
            return RedirectToAction("Index", new { id = model.RoleId });
        }
    }
}
