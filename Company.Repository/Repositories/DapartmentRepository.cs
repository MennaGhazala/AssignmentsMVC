using Company.Data.Context;
using Company.Data.Models;
using Company.Repository.Interfaces;

namespace Company.Repository.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
        

        public DepartmentRepository(CompanyDbContext context): base(context)
        {
           
        }
       
    }
}
