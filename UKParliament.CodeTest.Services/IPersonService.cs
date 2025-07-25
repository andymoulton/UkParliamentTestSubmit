using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public interface IPersonService
{
    public Person getById(int id);
    public List<Person> getAll();
}