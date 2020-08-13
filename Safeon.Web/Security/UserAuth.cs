using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Safeon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Safeon.Web.Security
{
    public class UserAuth
    {
        public static UserHandler UserAuthenticated;

        public void LoginAuthentication(User user)
        {
            //UserHandler userhandler = new UserHandler()
            //{
            //    UserId = user.Id.Value,
            //    Name = user.Name,
            //    Email = user.Email
            //};

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //AuthenticationManager.SignIn(new AuthenticationProperties {
            //    AllowRefresh = true,
            //    IsPersistent = true,
            //    ExpiresUtc = DateTime.UtcNow.AddDays(1)
            // });
        }



    }

}
