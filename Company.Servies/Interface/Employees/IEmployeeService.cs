using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Servies.Interface.Employees
{
     public  interface IEmployeeService
    {
        Employee GetEmployeeByName(string name);
        Employee GetById(int? id);
        IEnumerable<Employee> GetAll();

        void Add(Employee department);
        void Update(Employee department);
        void Delete(Employee department);
    }
}
