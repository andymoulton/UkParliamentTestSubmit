using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Data;
using System.Collections.Generic;

namespace UKParliament.CodeTest.Tests
{
    public class ValidationTest
    {

        [Fact]
        public void ValidatePerson_ReturnsErrors_WhenPersonIsInvalid()
        {
            // Arrange: create a person with missing required fields
            var person = new Person
            {
                Id = 1,
                FirstName = "",
                LastName = "",
                DateOfBirth = null,
                DepartmentId = 0
            };

            var validator = new ValidatePersonService(person);

            // Act
            List<string> errors = validator.ValidatePerson();

            // Assert
            Assert.Contains("First name is required.", errors);
            Assert.Contains("Last name is required.", errors);
            Assert.Contains("Date of birth is required.", errors);
            Assert.Contains("Department is required.", errors);
            Assert.Equal(4, errors.Count);
        }

        [Fact]
        public void ValidatePerson_ReturnsNoErrors_WhenPersonIsValid()
        {
            // Arrange: create a valid person
            var person = new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateOnly(1990, 1, 1),
                DepartmentId = 1
            };

            var validator = new ValidatePersonService(person);

            // Act
            List<string> errors = validator.ValidatePerson();

            // Assert
            Assert.Empty(errors);
        }

    }
}
