using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public CustomerAddress Address { get; set; }
    }
}
