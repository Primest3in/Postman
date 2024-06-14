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
    }
}
