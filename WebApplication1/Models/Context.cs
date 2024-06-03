using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Context : IdentityDbContext<AppUser, AppRole, string>
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CarFeatures> CarFeatures { get; set; }
        public DbSet<CarImages> CarImages { get; set; }

        public DbSet<Rent> Rents { get; set; }

    }
}
