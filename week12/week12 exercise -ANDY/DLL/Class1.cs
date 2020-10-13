using Microsoft.EntityFrameworkCore;
using System;

namespace DLL
{
    //https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5
    //https://itsallinthecode.com/ef-core-in-a-separate-class-library/

    public class DALContext : DbContext
    {
        public DALContext(DbContextOptions<DALContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
    }
}
