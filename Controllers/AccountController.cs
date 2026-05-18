using JobsApp.Models.Database;
using JobsApp.Models.Services;
using JobsApp.Models.Services.Intefaces;
using JobsApp.Models.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobsApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;
        public AccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            ViewData["Title"] = "Login";
            if (ModelState.IsValid)
            {
                User? logedUser = _userAccountService.loginUser(model.Email, model.Password);
                if (logedUser != null)
                {
                    List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, logedUser.name),
                    new Claim(ClaimTypes.Email, logedUser.email),
                    new Claim(ClaimTypes.Upn, logedUser.Id.ToString())
                };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid email or password");
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            return View();
        }


    }
}
