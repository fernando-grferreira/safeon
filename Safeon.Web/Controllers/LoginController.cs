using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Safeon.Web.Models;
using Safeon.Web.Models.Form;

namespace Safeon.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginForm loginModel)
        {

            if (LoginUser(loginModel.Username, loginModel.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginModel.Username)
                };

                var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                //Just redirect to our index after logging in. 
                return Redirect("/Home");
            }
            return View();
        }

        private bool LoginUser(string username, string password)
        {
            return true;
        }


        [HttpPost]
        public async Task<IActionResult> Logout(LoginForm loginModel)
        {
            await HttpContext.Authentication.SignOutAsync("safeon");
            return Redirect("/Login");
        }

    }
}