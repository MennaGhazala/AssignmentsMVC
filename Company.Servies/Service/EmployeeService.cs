using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Servies.Interface.Employees;

namespace Company.Servies.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
       

        public IEnumerable<Employee  > GetAll()
        {
            var employee = _unitOfWork.EmployeeRepository.GetAll();
            return employee;
        }


        public Employee GetById(int? id)
        {
            if (id is null) return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee == null)
                return null;
            return employee;
        }



        public IEnumerable<Employee> GetEmployeeByName(string name)
        =>
           _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
        

        void IEmployeeService.Add(Employee department)
        {
            var mappedDepartment = new Department
            {
                
                Name = department.Name,
                CreateAt = DateTime.Now,
                IsDeleted = false,
            };
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);

            _unitOfWork.Complete();
        }

        void IEmployeeService.Delete(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        IEnumerable<Employee> IEmployeeService.GetAll()
        {
            var employee = _unitOfWork.EmployeeRepository.GetAll();
            return employee;
        }

        Employee IEmployeeService.GetById(int? id)
        {
            if (id is null) return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee == null)
                return null;
            return employee;
        }

        Employee IEmployeeService.GetEmployeeByName(string name)
        {
            throw new NotImplementedException();
        }

        void IEmployeeService.Update(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
        }
    }
}
