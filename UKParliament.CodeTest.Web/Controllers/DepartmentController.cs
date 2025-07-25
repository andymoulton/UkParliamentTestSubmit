using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.ViewModels;

/* 
 * Controller for managing departments - limited to just returning all departments.
 * Calls Person service in business layer as related entities (person,department) need to be accessed through through one context.
*/

namespace UKParliament.CodeTest.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {

        private readonly PersonManagerContext _context;

        public DepartmentController(PersonManagerContext context)
        {
            _context = context;
        }

        [Route("all")]
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentViewModel>> GetAll()
        {

            try
            {
                var departments = new PersonService(_context).getAllDepartments();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
