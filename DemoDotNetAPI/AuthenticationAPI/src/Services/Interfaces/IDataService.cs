using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services.Interfaces
{
    public interface IDataService
    {
        List<UserIdentityModel> Get_AuthenData_By_Username(string username);
    }
}
