using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Postman.API.Data;
using Postman.API.Model.Domain;
using Postman.API.Model.DTO;

namespace Postman.API.Model.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly ApplicationDBContext dbContext;
        private readonly IMapper mapper;

        public WalkRepository(ApplicationDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.WalkTable.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.WalkTable.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UpdateWalkDTO> UpdateAsync(Guid id, UpdateWalkDTO updateWalkDTO)
        {
            var exisitingWalk = await dbContext.WalkTable.FirstOrDefaultAsync(x => x.Id == id);
            if(exisitingWalk != null)
            {
                exisitingWalk.Name = updateWalkDTO.Name;
                exisitingWalk.WalkImgUrl = updateWalkDTO.WalkImgUrl;
                exisitingWalk.Description = updateWalkDTO.Description;
                exisitingWalk.LengthInKM = updateWalkDTO.LengthInKM;
                exisitingWalk.DifficultyId = updateWalkDTO.DifficultyId;
                exisitingWalk.RegionId = updateWalkDTO.RegionId;
            }
            await dbContext.SaveChangesAsync();
            var updatedWalk = mapper.Map<UpdateWalkDTO>(exisitingWalk);
            return updatedWalk;

        }
    }
}
