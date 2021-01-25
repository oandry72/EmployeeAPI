using System;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.DBContexts
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables
            modelBuilder.Entity<Employee>().ToTable("employees");
            // Configure Primary Keys
            modelBuilder.Entity<Employee>().HasKey(en => en.emp_no).HasName("emp_no");
        }
    }
}