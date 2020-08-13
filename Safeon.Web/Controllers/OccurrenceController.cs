using Microsoft.AspNetCore.Mvc;

namespace Safeon.Web.Controllers
{
    public class OccurrenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View("Form");
        }
    }
}
