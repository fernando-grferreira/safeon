using System;
using System.Collections.Generic;
using System.Text;

namespace Safeon.Domain.Models
{
    public class Customer
    {
        public int? Id { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public Person Person { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
