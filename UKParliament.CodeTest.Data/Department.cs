namespace UKParliament.CodeTest.Data;

/*
 * Department class representing a department in the system.
 */
public class IDepartment
{
    int Id { get; set; }
    string? Name { get; set; }
}

public class Department : IDepartment
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
