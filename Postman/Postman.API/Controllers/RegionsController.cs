using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postman.API.Data;
using Postman.API.Model.Domain;
using Postman.API.Model.DTO;
using Postman.API.Model.Repositories;


namespace Postman.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(ApplicationDBContext dBContext, IRegionRepository regionRepository, IMapper mapper) {
            this._dbContext = dBContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET BY: api/Regions
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetAllAsync();
            var regionsDTO = mapper.Map< List<RegionDTO> >(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            var region = await regionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<RegionDTO>(region);

            return Ok(regionDTO);
        }
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionDTO addRegionDTO)
        {
            var region = mapper.Map<Region>(addRegionDTO);

            region = await regionRepository.CreateAsync(region);

            var regionDTO = mapper.Map<RegionDTO>(region);

            return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            var region = await regionRepository.UpdateAsync(id, updateRegionDTO);
            if(region ==  null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<UpdateRegionDTO>(region);
            return Ok(regionDTO);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<RegionDTO>(region); 
            return Ok(regionDTO);    
        }
    }
}
