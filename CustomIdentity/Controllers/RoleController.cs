﻿using CustomIdentity.Data;
using CustomIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomIdentity.Controllers
{
    [Authorize(Policy = "FullAdminAccess")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> _userManager)
        {
            _roleManager = roleManager;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public IActionResult Edit(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role != null)
            {
                return View(role);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, IdentityRole model)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (ModelState.IsValid)
            {
                if (role != null)
                {
                    role.Name = model.Name;
                    await _roleManager.UpdateAsync(role);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                NotFound();
            }
            return View(role);
        }

        public IActionResult Delete(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if(role.Name == CustomIdentity.Utilities.Helper.Admin)
            {
                ModelState.AddModelError("", "Admin Role is not allowed to delete");
                return View(ModelState);
            }
            if (role != null)
            {
                return View(role);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);

            if (usersInRole.Any())
            {
                ModelState.AddModelError("", "Cannot delete the role. Users are assigned to it.");
                return RedirectToAction(nameof(Index));
            }

            
            var result = await _roleManager.DeleteAsync(await _roleManager.FindByNameAsync(role.Name));

            if (result.Succeeded)
            {   
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(Index);
            }

        }
        public async Task<IActionResult> ManageUserRole(string id)
        {
            ViewBag.userId = id;
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRole(List<ManageUserRolesViewModel> model, string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View();
            }
            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("User","Account");
        }
    }

}
