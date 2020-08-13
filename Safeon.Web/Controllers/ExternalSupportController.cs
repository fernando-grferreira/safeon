using Microsoft.AspNetCore.Mvc;
using Safeon.Domain.Business.Contracts;
using Safeon.Domain.Models;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using Safeon.Web.Models.Form;
using Safeon.Web.Models.Result;
using System.Threading.Tasks;

namespace Safeon.Web.Controllers
{
    public class ExternalSupportController : Controller
    {
        private readonly IExternalSupportBusiness _externalSupportBusiness;

        public ExternalSupportController(IExternalSupportBusiness externalSupportBusiness)
        {
            _externalSupportBusiness = externalSupportBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Search(FilterRequest request)
        {
            PaginatedListResult<ExternalSupport> result = await _externalSupportBusiness.GetList(request);

            return Json(new
            {
                draw = request.Draw,
                recordsTotal = result.TotalCount,
                recordsFiltered = result.TotalCount,
                data = new ExternalSupportResult().ConvertTo(result.Data)
            });
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.ExternalSupportType = await _externalSupportBusiness.GetTypeList();

            return View("Form", new ExternalSupportForm());
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ExternalSupportType = await _externalSupportBusiness.GetTypeList();

            ExternalSupport model = await _externalSupportBusiness.Get(id);
            ExternalSupportForm form = new ExternalSupportForm(model);

            return View("Form", form);
        }

        [HttpPost()]
        public async Task<IActionResult> Save(ExternalSupportForm request)
        {
            ExternalSupport result = await _externalSupportBusiness.Save(request.FromBusiness());

            return RedirectToAction("Index");
        }
    }
}