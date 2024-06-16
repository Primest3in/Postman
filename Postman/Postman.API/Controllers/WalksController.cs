using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postman.API.Model.Domain;
using Postman.API.Model.DTO;
using Postman.API.Model.Repositories;

namespace Postman.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkDTO addWalkDTO)
        {
            var walk = mapper.Map<Walk>(addWalkDTO);
            walk = await walkRepository.CreateAsync(walk);
            return Ok(mapper.Map<WalkDTO>(walk));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            var walks = await walkRepository.GetAllAsync(filterOn, filterQuery);
            var walksDTO = mapper.Map<List<WalkDTO>>(walks);
            return Ok(walksDTO);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await walkRepository.GetByIdAsync(id);

            if (walk == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<WalkDTO>(walk);

            return Ok(walkDTO);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkDTO updateWalkDTO)
        {
            var walk = await walkRepository.UpdateAsync(id, updateWalkDTO);
            if (walk == null)
            {
                return NotFound();
            }
            
            return Ok(updateWalkDTO);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walk = await walkRepository.DeleteAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
            var walkDTO = mapper.Map<WalkDTO>(walk);
            return Ok(walkDTO);
        }
    }
}
