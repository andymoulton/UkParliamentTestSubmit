using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services
{

    /*    * This service is responsible for validating a Person entity.
     * It checks if the required fields are filled in and returns a list of error messages if any validation fails.
     * This service is called from the PersonController in the web project.
     */

    public class ValidatePersonService : IValidatePersonService
    {

        readonly IPerson _person;

        public ValidatePersonService(IPerson person)
        {
            _person = person ?? throw new ArgumentNullException(nameof(person));
        }

        // Validates the person entity and returns a list of error messages if any validation fails.
        public List<string> ValidatePerson()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(_person.FirstName))
                errors.Add("First name is required.");

            if (string.IsNullOrWhiteSpace(_person.LastName))
                errors.Add("Last name is required.");

            if (_person.DateOfBirth == default)
                errors.Add("Date of birth is required.");

            if (_person.DepartmentId == 0)
                errors.Add("Department is required.");

            // Date of birth input is limited in the form to a date control, so an invalid date cannot be specified, however, we can make checks on date rate.

            if (_person.DateOfBirth != null && _person.DateOfBirth > DateOnly.FromDateTime(DateTime.Today))
                errors.Add("Date of birth cannot be in the future.");

            if (_person.DateOfBirth != null && _person.DateOfBirth > DateOnly.FromDateTime(DateTime.Today.AddYears(-16)))
                errors.Add("This person is too young to be employed by this organisation.");

            if (_person.DateOfBirth != null && _person.DateOfBirth < DateOnly.FromDateTime(DateTime.Today.AddYears(-120)))
                errors.Add("Call Guinness World Records immediately !");


            return errors;
        }
    }
}
