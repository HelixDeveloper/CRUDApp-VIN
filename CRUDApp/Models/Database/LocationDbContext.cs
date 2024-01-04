using Microsoft.EntityFrameworkCore;

namespace CRUDApp.Models.Database
{
    public class LocationDbContext:DbContext
    {
        public LocationDbContext(DbContextOptions<LocationDbContext> options):base(options) { }

        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<StateModel> States { get; set; }
    }
}
