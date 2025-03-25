using Company.Data.Context;
using Company.Data.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;

        public GenericRepository(CompanyDbContext context) {
           _context = context;
        }
        public void Add(T Entity) {
            _context.Add(Entity);
            _context.SaveChanges();
                }
        
        

        public void Delete(T Entity)
        {
            _context.Remove(Entity);
            _context.SaveChanges();
        }



        public T GetById(int id)
       => _context.Set<T>().FirstOrDefault(x=>x.Id==id);

        public void Update(T Entity)
        {
            _context.Update(Entity);
            _context.SaveChanges();
        }
        IEnumerable<T> IGenericRepository<T>.GetAll()
        => _context.Set<T>().ToList();
    }
}
