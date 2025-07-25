namespace UKParliament.CodeTest.ViewModels
{
    public class IPersonViewModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateOnly? DateOfBirth { get; set; }
        int DepartmentId { get; set; }
        string? DepartmentName { get; set; }
    }

    public class PersonViewModel// : IPersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
