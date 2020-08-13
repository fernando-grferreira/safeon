using Safeon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safeon.Web.Models.Result
{
    public class CustomerResult
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public char PersonType { get; set; }
        public string RegisterDateTime { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerType { get; set; }
        public int? Id { get; set; }

        public CustomerResult FromModel(Customer model)
        {
            if (model == null)
                return null;

            return new CustomerResult
            {
                Id = model.Id,
                Name = model.Person.Name,
                Document = model.Person.Document,
                PersonType = model.Person.PersonType,
                PhoneNumber = model.Person.PhoneNumber,
                RegisterDateTime = model.RegisterDateTime.ToString(),
                CustomerType = model.CustomerType.Description
            };
        }

        public IEnumerable<CustomerResult> ConvertTo(IEnumerable<Customer> models)
        {
            if (models == null)
                return null;

            List<CustomerResult> result = new List<CustomerResult>();

            foreach (var model in models)
            {
                result.Add(FromModel(model));
            }

            return result;
        }
    }
}
