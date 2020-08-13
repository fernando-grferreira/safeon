using Safeon.Domain.Models;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Safeon.Domain.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        PaginatedListResult<Customer> GetCustomers(FilterRequest request);
        Task<Customer> Save(Customer request);
        Task<Customer> GetCustomer(int id);
    }
}
