using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Postman.API.Data
{
    public class ApplicationAuthDBContext : IdentityDbContext
    {
        public ApplicationAuthDBContext(DbContextOptions<ApplicationAuthDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "dc71b88e-212e-4a4e-884b-ab1393600947";
            var writerId = "44cf8410-26df-4328-85e9-3577d0b69eed";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name = "Reader",
                    NormalizedName = "READER"
                },
                new IdentityRole
                {
                    Id = writerId,
                    ConcurrencyStamp = writerId,
                    Name = "Writer",    
                    NormalizedName = "WRITER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
