using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetAll()
        {
            var regions = await _dbContext.RegionTable.ToListAsync();
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
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            var region = await _dbContext.RegionTable.FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task<IActionResult> Create([FromBody] AddRegionDTO addRegionDTO)
        {
            var region = new Region()
            {
                Code = addRegionDTO.Code,
                Name = addRegionDTO.Name,
                RegionImgUrl = addRegionDTO.RegionImgUrl
            };

            await _dbContext.RegionTable.AddAsync(region);
            await _dbContext.SaveChangesAsync();

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
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            var region = await _dbContext.RegionTable.FirstOrDefaultAsync(r => r.Id == id);
            if(region ==  null)
            {
                return NotFound();
            }
            region.Code = updateRegionDTO.Code;
            region.Name = updateRegionDTO.Name;
            region.RegionImgUrl = updateRegionDTO.RegionImgUrl;

            await _dbContext.SaveChangesAsync();
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
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await _dbContext.RegionTable.FirstOrDefaultAsync(x=> x.Id == id);
            if(region  == null)
            {
                return NotFound();
            }
            _dbContext.RegionTable.Remove(region);
            await _dbContext.SaveChangesAsync();

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
