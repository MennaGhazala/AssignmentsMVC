using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Servies.Interface.Departments;

namespace Company.Servies.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Department department)
        {
            var mappedDepartment = new Department
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = DateTime.Now,
                IsDeleted = false,
            };
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);

            _unitOfWork.Complete();
        }

        public void Delete(Department department)
        {
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Complete();
        }

        public IEnumerable<Department> GetAll()
        {
            var departmens = _unitOfWork.DepartmentRepository.GetAll();
            return departmens;
        }


        public Department GetById(int? id)
        {
            if (id is null) return null;
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department == null)
                return null;
            return department;
        }
        public void Update(Department department)
        {

            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();
        }


        
    }
}
