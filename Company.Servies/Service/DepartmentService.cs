using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Servies.Interface.Departments;
using Company.Servies.Interface.Dto;

namespace Company.Servies.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            /*var mappedDepartment = new DepartmentDto
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = DateTime.Now,
               
            };*/
            var mappedDepartment = _mapper.Map<Department>(departmentDto);
            mappedDepartment.CreateAt = DateTime.Now;
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);

            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var existingDepartment = _unitOfWork.DepartmentRepository.GetById(departmentDto.Id);
            if (existingDepartment == null) throw new Exception("Department not found");

           
            _mapper.Map(departmentDto, existingDepartment);

            
            _unitOfWork.DepartmentRepository.Delete(existingDepartment);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var departmens = _unitOfWork.DepartmentRepository.GetAll();
          IEnumerable<DepartmentDto> departmentDtos=  _mapper.Map<IEnumerable<DepartmentDto>>(departmens);
            return departmentDtos;
        }


        public DepartmentDto GetById(int? id)
        {
            if (id is null) return null;
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            
            return department == null ? null : _mapper.Map<DepartmentDto>(department);
        }
        public void Update(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();
        }


        
    }
}
