using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "Harsha", LastName = "Gihan", Province = "West", Email = "harshagihan@gmail.com", Phone = "0772565498", DOB = new DateTime(1999,02,17), Position = "Intern", Salary = 10000, Gender = "male", ProfilePicName="" },
                new Employee { EmployeeId = 2, FirstName = "Isuru", LastName = "Lakshan", Province = "North", Email = "isurulakshan@gmail.com", Phone = "0779685478", DOB = new DateTime(1999,08,17), Position = "Intern", Salary = 10000, Gender = "male", ProfilePicName="" },
                new Employee { EmployeeId = 3, FirstName = "Isuri", LastName = "Dilrukshi", Province = "North", Email = "isuri123@gmail.com", Phone = "0779865478", DOB = new DateTime(1999, 08, 17), Position = "Intern", Salary = 10000, Gender = "female", ProfilePicName = "" });

        }
    }
}
