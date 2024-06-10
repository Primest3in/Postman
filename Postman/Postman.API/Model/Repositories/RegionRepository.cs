using Microsoft.EntityFrameworkCore;
using Postman.API.Data;
using Postman.API.Model.Domain;
using Postman.API.Model.DTO;

namespace Postman.API.Model.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        ApplicationDBContext dbContext;
        public RegionRepository(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.RegionTable.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await dbContext.RegionTable.FirstOrDefaultAsync(x => x.Id == id);
            if(region !=  null)
            {
                dbContext.RegionTable.Remove(region);
                await dbContext.SaveChangesAsync();
            }
            
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.RegionTable.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.RegionTable.FirstOrDefaultAsync(x => x.Id == id);  
        }

        public async Task<UpdateRegionDTO?> UpdateAsync(Guid id, UpdateRegionDTO updateRegionDTO)
        {
            var existingRegion = await dbContext.RegionTable.FirstOrDefaultAsync(x => x.Id == id);
            if(existingRegion != null)
            {
                existingRegion.Code = updateRegionDTO.Code;
                existingRegion.Name = updateRegionDTO.Name;
                existingRegion.RegionImgUrl = updateRegionDTO.RegionImgUrl;
            }
            await dbContext.SaveChangesAsync();
            return updateRegionDTO;
        }
    }
}
