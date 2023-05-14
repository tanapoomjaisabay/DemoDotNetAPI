using CustomerAPI.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.DataAccess
{
    public class CustomerInfoContext : DbContext, CustomerInfoDataSet
    {
        public DbSet<CustomerMasterInfoEntity> custMasterInfoEntity => Set<CustomerMasterInfoEntity>();

        public CustomerInfoContext(DbContextOptions<CustomerInfoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var customeAuthenBuilder = builder.Entity<CustomerMasterInfoEntity>();
            customeAuthenBuilder.ToTable("customer_master_info", "dbo");
            customeAuthenBuilder.HasKey(x => new { x.idKey });
            customeAuthenBuilder.Property(x => x.idKey).ValueGeneratedOnAdd();

        }
    }
}
