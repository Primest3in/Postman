using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postman.API.Data;
using Postman.API.Model.Domain;
using Postman.API.Model.DTO;


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
            var regionsDTO = new List<RegionDTO>();
            foreach (var region in regions)
            {
                regionsDTO.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImgUrl = region.RegionImgUrl
                    
                });
            }
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id) {
            var region = _dbContext.RegionTable.FirstOrDefault(x => x.Id == id);
            if(region == null)
            {
                return NotFound();
            }

            var regionDTO = new RegionDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImgUrl = region.RegionImgUrl
            };
            return Ok(regionDTO);
        }
    }

    
}
