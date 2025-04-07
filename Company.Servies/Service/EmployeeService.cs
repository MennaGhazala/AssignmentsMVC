using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Servies.Helper;
using Company.Servies.Interface.Dto;
using Company.Servies.Interface.Employees;

namespace Company.Servies.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
       

        public IEnumerable<EmployeeDto  > GetAll()
        {
            var employee = _unitOfWork.EmployeeRepository.GetAll();
           /* var mappEmployee = employee.Select(x => new EmployeeDto
            {

                Id = x.Id,
                DepartmentId = x.DepartmentId,
                Name = x.Name,
                HiringDate = x.HiringDate,
                Email = x.Email,
                ImageUrl = x.ImageUrl,
                PhoneNumber = x.PhoneNumber,
                Salary = x.Salary,
                Age = x.Age,
                CreateAt = x.CreateAt,
            });*/
          IEnumerable<EmployeeDto> mappEmployee= _mapper.Map<IEnumerable< EmployeeDto>>(employee);
            return mappEmployee;
        }


        public EmployeeDto GetById(int? id)
        {
            if (id is null) return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            /* EmployeeDto employeeDto = new EmployeeDto
             {

                 Name = employee.Name,
                 Age = employee.Age,
                 Salary = employee.Salary,
                 Email = employee.Email,
                 PhoneNumber = employee.PhoneNumber,
                 HiringDate = employee.HiringDate,
                 ImageUrl = employee.ImageUrl,
                 Id= employee.Id,
                 CreateAt= employee.CreateAt,
                 DepartmentId = employee.DepartmentId,
             };*/
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

            if (employeeDto == null)
                return null;
            return employeeDto;
        }



        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employee = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            /*  var mappEmployee = employee.Select(x => new EmployeeDto
              {

                  Id = x.Id,
                  DepartmentId = x.DepartmentId,
                  Name = x.Name,
                  HiringDate = x.HiringDate,
                  Email = x.Email,
                  ImageUrl = x.ImageUrl,
                  PhoneNumber = x.PhoneNumber,
                  Salary = x.Salary,
                  Age = x.Age,
                  CreateAt = x.CreateAt,
              });*/
            IEnumerable<EmployeeDto> mappEmployee = _mapper.Map<IEnumerable<EmployeeDto>>(employee);

            return mappEmployee;
        
        }

        void IEmployeeService.Add(EmployeeDto employeeDto)
        {// manual mapping
            /* Employee employee = new Employee
             {

                 Name = employeeDto.Name,
                 Age = employeeDto.Age,
                 Salary = employeeDto.Salary,
                 Email = employeeDto.Email,
                 PhoneNumber = employeeDto.PhoneNumber,
                 HiringDate = employeeDto.HiringDate,
                 ImageUrl = employeeDto.ImageUrl,

                DepartmentId = employeeDto.DepartmentId,
             };*/
            employeeDto.ImageUrl = DocumentSetting.UploadFile(employeeDto.Image,"Images");
             Employee employee= _mapper.Map<Employee>(employeeDto);
            employee.HiringDate = DateTime.Now;
            _unitOfWork.EmployeeRepository.Add( employee);

            _unitOfWork.Complete();
        }

        void IEmployeeService.Delete(EmployeeDto employeeDto)
        {
            /* Employee employee= new Employee
             {

                 Name = employeeDto.Name,
                 Age = employeeDto.Age,
                 Salary = employeeDto.Salary,
                 Email = employeeDto.Email,
                 PhoneNumber = employeeDto.PhoneNumber,
                 HiringDate = employeeDto.HiringDate,
                 ImageUrl = employeeDto.ImageUrl,

                 DepartmentId = employeeDto.DepartmentId,
             };*/
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

       

        void IEmployeeService.Update(EmployeeDto employeeDto)
        {
            var existingEmployee = _unitOfWork.EmployeeRepository.GetById(employeeDto.Id);
            if (existingEmployee == null)
                throw new Exception("Employee not found");

            // Map updated fields from DTO to entity
            _mapper.Map(employeeDto, existingEmployee);

            _unitOfWork.EmployeeRepository.Update(existingEmployee);
            _unitOfWork.Complete();
        }
    }
}
