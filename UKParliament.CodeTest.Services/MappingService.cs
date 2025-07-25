using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.ViewModels;

namespace UKParliament.CodeTest.Services
{
    /* This service is responsible for mapping between the Person entity and the PersonViewModel.
    */

    public class MappingService : IMappingService
    {

        // Maps a Person entity to a PersonViewModel.
        public PersonViewModel MapToViewModel(Person _person)
        {
            if (_person == null) throw new ArgumentNullException(nameof(_person));

            return new PersonViewModel
            {
                FirstName = _person.FirstName,
                LastName = _person.LastName,
                DateOfBirth = _person.DateOfBirth,
                DepartmentId = _person.DepartmentId,
                DepartmentName = _person.DepartmentName
            };

        }

        // Maps a PersonViewModel to a Person entity.
        public Person MapToEntity(PersonViewModel _personViewModel)
        {
            if (_personViewModel == null) throw new ArgumentNullException(nameof(_personViewModel));

            return new Person
            {
                FirstName = _personViewModel.FirstName,
                LastName = _personViewModel.LastName,
                DateOfBirth = _personViewModel.DateOfBirth,
                DepartmentId = _personViewModel.DepartmentId
            };
        }
    }
}
