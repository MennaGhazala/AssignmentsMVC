using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Servies.Interface;

namespace Company.Servies.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department department)
        {
            var mappedDepartment = new Department
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = DateTime.Now,
            };
            _departmentRepository.Add(mappedDepartment);
        }

        public void Delete(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            var departmens = _departmentRepository.GetAll();
            return departmens;
        }


        public Department GetById(int? id)
        {
            if (id is null) return null;
            var department = _departmentRepository.GetById(id.Value);
            if (department == null)
                return null; return department;
        }
        public void Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
