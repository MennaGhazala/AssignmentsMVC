using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class Department :BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
