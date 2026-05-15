using JobsApp.Models.Database;
using JobsApp.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserAccountService _userAccountService;
        public AccountController(UserAccountService userAccountService)
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
        public ActionResult Login(string userEmail, string password)
        {
            User? logedUser = _userAccountService.loginUser(userEmail, password);
            if(logedUser != null)
            {
                
            }
            ViewData["loginError"] = "something went worng";
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            return View();
        }


    }
}
