using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services.Interfaces
{
    public interface ITokenService
    {
        ResponseTokenModel RequestToken(RequestAuthenModel model);
    }
}
