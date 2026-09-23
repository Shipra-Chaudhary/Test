using Microsoft.EntityFrameworkCore;
using TestCase.Models;

namespace TestCase.Models
{
    public class EmployeeDBContext :DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}




