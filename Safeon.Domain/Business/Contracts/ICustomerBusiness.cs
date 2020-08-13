using Safeon.Domain.Models;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Safeon.Domain.Business.Contracts
{
    public interface ICustomerBusiness
    {
        PaginatedListResult<Customer> GetCustomers(FilterRequest request);
        Task<Customer> Save(Customer request);
        Task<Customer> GetCostumer(int id);
    }
}
