using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Safeon.Domain.Business.Contracts;
using Safeon.Domain.Models;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using Safeon.Web.Models.Result;

namespace Safeon.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerBusiness _customerBusiness;

        public IActionResult Index()
        {
            return View();
        }

        public CustomerController(ICustomerBusiness iCustomerBusiness)
        {
            _customerBusiness = iCustomerBusiness;
        }

        [HttpPost()]
        public IActionResult Search(FilterRequest request)
        {
            PaginatedListResult<Customer> result = _customerBusiness.GetCustomers(request);

            return Json(new
            {
                draw = request.Draw,
                recordsTotal = result.TotalCount,
                recordsFiltered = result.TotalCount,
                data = new CustomerResult().ConvertTo(result.Data)
            });
        }
    }
}