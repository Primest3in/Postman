using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Postman.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            string[] studentNames = new string[] {"A", "B","C", "D", "E"};

            return Ok(studentNames);
        }

    }
}
