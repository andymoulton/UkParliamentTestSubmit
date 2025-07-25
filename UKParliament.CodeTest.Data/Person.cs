using System.Net.Sockets;

namespace UKParliament.CodeTest.Data;

/*
 * Person class representing a person in the system.
 */

public interface IPerson
{
     int Id { get; set; }
     string? FirstName { get; set; }
     string? LastName { get; set; }
     string? Email { get; set; }
     DateOnly? DateOfBirth { get; set; }
     int DepartmentId { get; set; }
     string? DepartmentName { get; set; } // Added just to make it available in TS client
     int PersonId { get; set; }

}

public class Person : IPerson
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; } // Added just to make it available in TS client
    public int PersonId {get; set; } 

}