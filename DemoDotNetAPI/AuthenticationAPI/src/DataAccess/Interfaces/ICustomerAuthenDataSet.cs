using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.DataAccess.Interfaces
{
    public interface ICustomerAuthenDataSet
    {
        DbSet<CustAuthenEntity> authenEntity { get; }
    }
}
