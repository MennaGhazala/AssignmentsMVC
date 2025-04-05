using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Servies.Interface.Departments
{
    public interface IDepartmentService
    {
        Department GetById(int? id);
        IEnumerable<Department> GetAll();

        void Add(Department department);
        void Update(Department department);
        void Delete(Department department);
    }
}
