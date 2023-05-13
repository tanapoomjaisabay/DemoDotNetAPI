using AuthenticationAPI.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.DataAccess
{
    public class CustomerAuthenContext : DbContext, ICustomerAuthenDataSet
    {
        public DbSet<CustAuthenEntity> authenEntity => Set<CustAuthenEntity>();

        public CustomerAuthenContext(DbContextOptions<CustomerAuthenContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var customeAuthenBuilder = builder.Entity<CustAuthenEntity>();
            customeAuthenBuilder.ToTable("customer_authen", "dbo");
            customeAuthenBuilder.HasKey(x => new { x.idKey });
            customeAuthenBuilder.Property(x => x.idKey).ValueGeneratedOnAdd();

        }
    }

}