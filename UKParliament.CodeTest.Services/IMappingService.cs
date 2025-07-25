using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.ViewModels;

namespace UKParliament.CodeTest.Services
{
    internal interface IMappingService
    {
        public PersonViewModel MapToViewModel(Person _person);
        public Person MapToEntity(PersonViewModel _personViewModel);
    }
}
