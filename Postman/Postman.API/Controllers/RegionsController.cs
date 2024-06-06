using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postman.API.Data;
using Postman.API.Model.Domain;

namespace Postman.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public RegionsController(ApplicationDBContext dBContext) {
            this._dbContext = dBContext;                 
        }

        // GET BY: api/Regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _dbContext.RegionTable.ToList();
            return Ok(regions);
        }
    }
}
