using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services
{

    /*
     * This service is called from the DepartmewntController in the web project. 
     * The DB context is passed in from the web project, which allows for easier testing and separation of concerns.
     */

    public class DepartmentService : IDepartmentService
    {

        private readonly DbContext _context;

        public DepartmentService(DbContext context)
        {
            _context = context;
        }

        protected DbSet<Department> Departments => (_context as PersonManagerContext)?.Departments
                                         ?? _context.Set<Department>();

        // Returns all departments
        public List<Department> GetAll()
        {
            var departments = Departments
            .Select(dept => new Department
            {
                 Id = dept.Id,
                 Name = dept.Name
            })
            .ToList();
            return departments;
        }
    }
}
