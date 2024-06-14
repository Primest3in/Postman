using Microsoft.EntityFrameworkCore;
using Postman.API.Data;
using Postman.API.Model.Domain;

namespace Postman.API.Model.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly ApplicationDBContext dbContext;

        public WalkRepository(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
