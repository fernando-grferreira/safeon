using Safeon.Domain.Business.Contracts;
using Safeon.Domain.Models;
using Safeon.Domain.Repositories.Contracts;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Safeon.Domain.Business
{
    public class CustomerBusiness : ICustomerBusiness
    {
        public ICustomerRepository _iCustomerRepository;

        public CustomerBusiness(ICustomerRepository customerRepository)
        {
            _iCustomerRepository = customerRepository;
        }

        public Task<Customer> GetCostumer(int id)
        {
            throw new NotImplementedException();
        }

        public PaginatedListResult<Customer> GetCustomers(FilterRequest request)
        {
            return _iCustomerRepository.GetCustomers(request);
        }

        public Task<Customer> Save(Customer request)
        {
            throw new NotImplementedException();
        }
    }
}
