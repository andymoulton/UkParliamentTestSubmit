using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Data
{

    public class DepartmentManagerContext : DbContext
    {
        public DepartmentManagerContext(DbContextOptions<DepartmentManagerContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Department>().HasData(              // Seed initial data for Departments
                new Department { Id = 1, Name = "Sales" },
                new Department { Id = 2, Name = "Marketing" },
                new Department { Id = 3, Name = "Finance" },
                new Department { Id = 4, Name = "HR" });

        }

    }
}
