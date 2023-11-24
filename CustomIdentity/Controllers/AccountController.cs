using CustomIdentity;
using CustomIdentity.Data;
using CustomIdentity.Models;
using CustomIdentity.Models.ViewModels;
using CustomIdentity.Repository;
using CustomIdentity.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NETCore.MailKit.Core;
using NuGet.Common;
//using NETCore.MailKit.Core;
using System.Net.Mail;
using System.Text;

namespace CustomIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        SignInManager<ApplicationUser> _signInManager;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender emailService;

        public AccountController(ApplicationDbContext dbContext,
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager, IEmailSender _emailService)
        {
            this.dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            emailService = _emailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginModel.Email);
                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid Login attempt");
            return View(loginModel);
        }

        [Authorize(policy: "CreateUserRights")]
        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.User));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Operator));

            }
            var registeruser = new RegisterModel
            {
                Roles = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }).ToList()
            };


            return View(registeruser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "CreateUserRights")]
        public async Task<IActionResult> RegisterAsync(string? id, RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(id))
                {
                    var user = new ApplicationUser
                    {
                        UserName = registerModel.EmailAddress,
                        Email = registerModel.EmailAddress,
                        Name = registerModel.Name
                    };

                    var result = await _userManager.CreateAsync(user, registerModel.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, registerModel.RoleName);
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {

                    var user = await _userManager.FindByIdAsync(id);

                    if (user != null)
                    {
                        user.UserName = registerModel.Name;
                        user.Email = registerModel.EmailAddress;
                        user.Name = registerModel.Name;

                        var result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            //await _userManager.AddToRoleAsync(user, registerModel.RoleName);
                            //await _signInManager.SignInAsync(user, isPersistent: false);
                            return RedirectToAction(nameof(User));
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }




                }


            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> User()
        {
            var users = _userManager.Users.Select(u => new UserListVM
            {
                UserId = u.Id,
                UserName = u.Name,
                Email = u.Email,
                Roles = _userManager.GetRolesAsync(u).Result.ToList()
            }).ToList();

            return View(users);
        }
        [HttpGet]
        [Authorize(policy: "EditUserRights")]
        public IActionResult EditUser(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;


            if (user != null)
            {
                var resultuser = new UserEdit
                {
                    Name = user.Name,
                    EmailAddress = user.Email
                };
                return View(resultuser);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(policy: "DeleteUserRights")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "DeleteUserRights")]
        public async Task<IActionResult> DeleteConfirmed(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(user));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("DeleteUser", user);
            }
        }
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    var resetLink = Url.Action("ResetPassword", "Account", new { userId = user.Id, token }, Request.Scheme);

                    var emailBuilder = new StringBuilder();
                    emailBuilder.Append("<html>");
                    emailBuilder.Append("<body>");

                    emailBuilder.Append($"Dear {user.Name} !");
                    emailBuilder.Append("<br/>");
                    emailBuilder.Append($"Password Reset Link for {user.UserName} is here: ");
                    emailBuilder.Append($"<a href='{resetLink}'>Reset Password</a>");
                    emailBuilder.Append("</body>");
                    emailBuilder.Append("</html>");

                    string emailBody = emailBuilder.ToString();

                    var message = new Message(new string[] { user.Email }, "Password Recovery", emailBody);
                    emailService.SendEmail(message);

                    ViewBag.ResetLink = resetLink;
                    return View("ForgotPasswordConfirmation");
                }
                else
                {
                    ViewBag.ErrorMessage = "No User Found with email you provided";
                    return View("ForgotPasswordConfirmation");
                }
            }

            return View(model);
        }
        [AllowAnonymous]
        public IActionResult ResetPassword(string userId, string token)
        {
            var model = new ResetPasswordViewModel
            {
                UserId = userId,
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return View(nameof(Login));
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }

                return View(nameof(Login));
            }

            return View(model);
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}