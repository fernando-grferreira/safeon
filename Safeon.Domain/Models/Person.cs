using System;
using System.Collections.Generic;
using System.Text;

namespace Safeon.Domain.Models
{
    public class Person
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public char PersonType { get; set; }
        public string PhoneNumber { get; set; }
    }
}
