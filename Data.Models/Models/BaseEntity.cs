using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class BaseEntity
    {
        public  int Id { get; set; }
        public bool IsDeleted {  get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
