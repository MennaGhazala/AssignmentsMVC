using Company.Data.Context;
using Company.Data.Models;
using Company.Repository.Interfaces;

namespace Company.Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context) :base(context) 
        {
            _context = context;
        }

        public Employee GetEmployeeByName(string name)
        =>_context.Set<Employee>().FirstOrDefault(x=>x.Name==name);
    }
}
