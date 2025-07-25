using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services
{
    internal interface IValidatePersonService
    {
        public List<string> ValidatePerson();
    }
}
