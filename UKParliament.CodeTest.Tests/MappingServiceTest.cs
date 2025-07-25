using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.ViewModels;
using Xunit;

namespace UKParliament.CodeTest.Tests
{
    public class MappingServiceTest
    {
        [Fact]
        public void MapToViewModel_MapsPersonToViewModelCorrectly()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "Alice",
                LastName = "Smith",
                DateOfBirth = new DateOnly(1990, 1, 1),
                DepartmentId = 2,
                DepartmentName = "HR"
            };
            var service = new MappingService();

            // Act
            var viewModel = service.MapToViewModel(person);

            // Assert
            Assert.Equal("Alice", viewModel.FirstName);
            Assert.Equal("Smith", viewModel.LastName);
            Assert.Equal(new DateOnly(1990, 1, 1), viewModel.DateOfBirth);
            Assert.Equal(2, viewModel.DepartmentId);
            Assert.Equal("HR", viewModel.DepartmentName);
        }

        [Fact]
        public void MapToEntity_MapsViewModelToPersonCorrectly()
        {
            // Arrange
            var viewModel = new PersonViewModel
            {
                FirstName = "Bob",
                LastName = "Jones",
                DateOfBirth = new DateOnly(1985, 5, 5),
                DepartmentId = 1,
                DepartmentName = "Sales"
            };
            var service = new MappingService();

            // Act
            var person = service.MapToEntity(viewModel);

            // Assert
            Assert.Equal("Bob", person.FirstName);
            Assert.Equal("Jones", person.LastName);
            Assert.Equal(new DateOnly(1985, 5, 5), person.DateOfBirth);
            Assert.Equal(1, person.DepartmentId);
            // DepartmentName is not mapped in MapToEntity, so it should be null
            Assert.Null(person.DepartmentName);
        }

        [Fact]
        public void MapToViewModel_ThrowsArgumentNullException_WhenPersonIsNull()
        {
            var service = new MappingService();
            Assert.Throws<ArgumentNullException>(() => service.MapToViewModel(null));
        }

        [Fact]
        public void MapToEntity_ThrowsArgumentNullException_WhenViewModelIsNull()
        {
            var service = new MappingService();
            Assert.Throws<ArgumentNullException>(() => service.MapToEntity(null));
        }
    }
}
