using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

/*
 * This service is called from the PersonController in the web project. 
 * The DB context is passed in from the web project, which allows for easier testing and separation of concerns.
 */

public class PersonService : IPersonService
{

    private readonly DbContext _context;

    public PersonService(DbContext context)
    {
        _context = context;
    }

    protected DbSet<Person> People => (_context as PersonManagerContext)?.People
                                         ?? _context.Set<Person>();

    protected DbSet<Department> Departments => (_context as PersonManagerContext)?.Departments
                                 ?? _context.Set<Department>();

    // Returns a person by ID, or null if not found
    public Person getById(int id)
    {
        var person = People.Find(id);
        return person; // Returns null if not found
    }

    // Returns a list of all persons with their department names
    public List<Person> getAll()
    {
        var people = People
        .Select(person => new Person
        {
           FirstName = person.FirstName,
           LastName = person.LastName,
           DateOfBirth = person.DateOfBirth,
           Id = person.Id,
           Email = person.Email,
           DepartmentId = person.DepartmentId,
           DepartmentName = GetDepartmentName(person.DepartmentId)
        })
        .ToList();
        return people;
    }

    // Returns a list of all departments
    public List<Department> getAllDepartments()
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

    // Saves a person to the database. If the person has an Id of 0, it is treated as a new person.
    public void Save(Person person)
    {
        if (person.Id == 0)
        {
            People.Add(person);
        }
        else
        {
            People.Update(person);
        }
        _context.SaveChanges();
    }

    // Deletes a person from the database
    public void Delete(Person person)
    {
        People.Remove(person);
        _context.SaveChanges();
    }

    // Gets the name of the department by its ID
    public string? GetDepartmentName(int departmentId)
    {
        var department = _context.Set<Department>().Find(departmentId);
        return department?.Name;
    }

}