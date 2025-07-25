using Microsoft.EntityFrameworkCore;

namespace UKParliament.CodeTest.Data;

/*
 * PersonManagerContext class representing the database context for managing persons and departments.
 */

public class PersonManagerContext : DbContext
{
    public PersonManagerContext(DbContextOptions<PersonManagerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var random = new Random();
        DateOnly today = DateOnly.FromDateTime(DateTime.Today.AddYears(-50));

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Sales" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Finance" },
            new Department { Id = 4, Name = "HR" });

        string[] FirstNames = new string[] { "Andy", "Duncan", "Sarah", "Peter", "Claire", "Katia", "Ronnie", "Laura", "Inam", "Syed", "Deniz", "Apostolos", "Tim" };
        string[] LastNames = new string[] { "Walker", "White", "Edwards", "Hughes", "Wood", "Turner", "Bennett", "Moore", "Young", "Jackson", "Phillips", "Patel", "Cooper" };

        for (int i =1; i <= 100; i++)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = i, FirstName = FirstNames[random.Next(FirstNames.Length)], LastName = LastNames[random.Next(LastNames.Length)], DepartmentId = random.Next(1, 4), DateOfBirth = DateOnly.FromDateTime(DateTime.Today.AddYears(-random.Next(18, 61))) }
            );
        }

    }

    public DbSet<Person> People { get; set; }

    public DbSet<Department> Departments { get; set; }

}