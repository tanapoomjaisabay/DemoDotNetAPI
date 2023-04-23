using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.DataAccess
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<CustomerInfoEntity>? custInfoEntity { get; set; }
    }
}
