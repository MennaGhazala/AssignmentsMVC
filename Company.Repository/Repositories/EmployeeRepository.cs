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

        public IEnumerable<Employee> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< Employee >GetEmployeeByName(string name)
        =>_context.Set<Employee>().Where(x=>x.Name.Trim() .ToLower().Contains(name.Trim().ToLower())).ToList();
    }
}
