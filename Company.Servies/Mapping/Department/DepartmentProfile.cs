using AutoMapper;
using Company.Data.Models;
using Company.Servies.Interface.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Servies.Mapping
{ 
    public class DepartmentProfile :Profile
    {
        public DepartmentProfile() {
                CreateMap<Department, DepartmentDto>().ReverseMap();

        }
    }
}
