using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services.Interfaces
{
    public interface IDataService
    {
        CustAuthenModel Get_AuthenData_By_Username(string username);
    }
}
