using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureTaskManager.Models;
using System.Security.Claims;

namespace SecureTaskManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;

            _signInManager = signInManager;
        }

        //
        // REGISTER PAGE
        //
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //
        // REGISTER USER
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(
                user,
                model.Password);

            if (result.Succeeded)
            {
                // Add Role
                await _userManager.AddToRoleAsync(user, "User");

                // Add Claim
                await _userManager.AddClaimAsync(
                    user,
                    new Claim("CanEditTask", "true"));

                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(
                    "",
                    error.Description);
            }

            return View(model);
        }

        //
        // LOGIN PAGE
        //
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //
        // LOGIN USER
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    false,
                    lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return RedirectToAction(
                    "Dashboard",
                    "User");
            }

            ModelState.AddModelError(
                "",
                "Invalid login attempt");

            return View(model);
        }

        //
        // LOGOUT
        //
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        //
        // ACCESS DENIED
        //
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}