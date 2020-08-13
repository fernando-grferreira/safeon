using Safeon.Domain.Contexts.Contracts;
using Safeon.Domain.Models;
using Safeon.Domain.Repositories.Contracts;
using Safeon.Mysql.Context;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Safeon.Mysql.Entities;
using Safeon.Systems.Utils;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Safeon.Mysql.Factories;

namespace Safeon.Mysql.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SafeonMysqlContext db;

        public CustomerRepository(ISafeonMysqlContext context)
        {
            db = (SafeonMysqlContext)context;
        }

        public Task<Customer> GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public PaginatedListResult<Customer> GetCustomers(FilterRequest request)
        {
            var query = db.ClientEntities
                .Include(x => x.Person)
                .Include(x=> x.ClientType)
                .AsQueryable();

            if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Value))
                query = query.Where(x => x.Person.Name.Contains(request.Search.Value) ||
                    x.Person.Document.Contains(request.Search.Value) ||
                    x.Person.PhoneNumber.Contains(request.Search.Value));

            return query.GetPaged(SafeonMysqlModelFactory.Create, request);
        }

        public Task<Customer> Save(Customer request)
        {
            throw new NotImplementedException();
        }
    }
}
