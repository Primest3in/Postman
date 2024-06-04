using Microsoft.EntityFrameworkCore;
using Postman.API.Model.Domain;

namespace Postman.API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }

        public DbSet<Difficulty> DifficultyTable { get; set; }
        public DbSet<Region> RegionTable { get; set; }
        public DbSet<Walk> WalkTable { get; set; }

    }
}
