using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Safeon.Web.Models;

namespace Safeon.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //if (HttpContext != null)
            //{
            //    var loggedInUser = HttpContext.User;
            //    var loggedInUserName = loggedInUser.Identity.Name; // This is our username we set earlier in the claims. 
            //    var loggedInUserName2 = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value; //Another way to get the name or any other claim we set. 
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
