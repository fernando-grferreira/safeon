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
    public class PointInterestController : Controller
    {
        private readonly IPointInterestBusiness _pointInterestBusiness;

        public PointInterestController(IPointInterestBusiness pointInterestBusiness)
        {
            _pointInterestBusiness = pointInterestBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Search(FilterRequest request)
        {
            PaginatedListResult<PointInterest> result = await _pointInterestBusiness.GetPointsInterest(request);

            return Json(new
            {
                draw = request.Draw,
                recordsTotal = result.TotalCount,
                recordsFiltered = result.TotalCount,
                data = new PointInterestResult().ConvertTo(result.Data)
            });
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.PointInterestType = await _pointInterestBusiness.GetPointsInterestTypes();

            return View("Form", new PointInterestForm());
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.PointInterestType = await _pointInterestBusiness.GetPointsInterestTypes();

            PointInterest model = await _pointInterestBusiness.GetPointInterest(id);
            PointInterestForm form = new PointInterestForm(model);

            return View("Form", form);
        }

        [HttpPost()]
        public async Task<IActionResult> Save(PointInterestForm request)
        {
            PointInterest result = await _pointInterestBusiness.Save(request.FromBusiness());

            return RedirectToAction("Index");
        }
    }
}