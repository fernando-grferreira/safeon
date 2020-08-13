using System;
using System.Collections.Generic;
using System.Text;

namespace Safeon.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
