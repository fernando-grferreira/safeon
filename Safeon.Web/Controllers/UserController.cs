using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Safeon.Domain.Business.Contracts;
using Safeon.Domain.Models;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using Safeon.Web.Models.Form;
using Safeon.Web.Models.Result;
using Safeon.Web.Security;

namespace Safeon.Web.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserBusiness _userBusiness;

        public IActionResult Index()
        {
            return View();
        }

        public UserController(IUserBusiness iUserBusiness)
        {
            _userBusiness = iUserBusiness;
        }

        [HttpPost()]
        public IActionResult Search(FilterRequest request)
        {
            PaginatedListResult<User> result =  _userBusiness.GetUsers(request);

            return Json(new
            {
                draw = request.Draw,
                recordsTotal = result.TotalCount,
                recordsFiltered = result.TotalCount,
                data = new UserResult().ConvertTo(result.Data)
            });
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.Profiles = await _userBusiness.GetProfiles();

            return View("Form", new UserForm());
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Profiles = await _userBusiness.GetProfiles();

            User model = await _userBusiness.GetUser(id);
            UserForm form = new UserForm(model);

            return View("Form", form);
        }

        [HttpPost()]
        public async Task<IActionResult> Save(UserForm request)
        {
            User result = await _userBusiness.Save(request.FromBusiness());

            return RedirectToAction("Index");
        }

    }
}