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
            if (region == null)
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
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionDTO addRegionDTO)
        {
            var region = new Region()
            {
                Code = addRegionDTO.Code,
                Name = addRegionDTO.Name,
                RegionImgUrl = addRegionDTO.RegionImgUrl
            };

            _dbContext.RegionTable.Add(region);
            _dbContext.SaveChanges();

            var regionDTO = new RegionDTO()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImgUrl = region.RegionImgUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            var region = _dbContext.RegionTable.FirstOrDefault(r => r.Id == id);
            if(region ==  null)
            {
                return NotFound();
            }
            region.Code = updateRegionDTO.Code;
            region.Name = updateRegionDTO.Name;
            region.RegionImgUrl = updateRegionDTO.RegionImgUrl;

            _dbContext.SaveChanges();
            var regionDTO = new RegionDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImgUrl = region.RegionImgUrl,

            };
            return Ok(regionDTO);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var region = _dbContext.RegionTable.FirstOrDefault(x=> x.Id == id);
            if(region  == null)
            {
                return NotFound();
            }
            _dbContext.RegionTable.Remove(region);
            _dbContext.SaveChanges();

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
