using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services.Interfaces
{
    public interface IAuthenService
    {
        ResponseAuthenModel LoginUserPssword(RequestAuthenModel model);
    }
}
