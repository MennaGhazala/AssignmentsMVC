using Company.Data.Models;
using Company.Servies.Interface.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Servies.Interface.Employees
{
     public  interface IEmployeeService
    {
         IEnumerable<  EmployeeDto> GetEmployeeByName(string name);
        EmployeeDto GetById(int? id);
        IEnumerable<EmployeeDto> GetAll();

        void Add(EmployeeDto department);
        void Update(EmployeeDto department);
        void Delete(EmployeeDto department);
    }
}
