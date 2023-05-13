using APIHelperLIB.Service;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Services
{
    public class AuthenService : IAuthenService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpConnectService _httpConnect;
        private readonly IDataService _dataService;

        public AuthenService(IConfiguration configuration, IHttpConnectService httpConnect, IDataService dataService)
        {
            _configuration = configuration;
            _httpConnect = httpConnect;
            _dataService = dataService;
        }

        public ResponseAuthenModel LoginUserPssword(RequestAuthenModel model)
        {
            try
            {
                UserIdentityModel userIdentity = VerifyUserName(model);
                VerifyPassword(userIdentity, model.password);

                var data = GetCustomerInfo(model);
                data.token = GenrateUserToken(data, model);

                return new ResponseAuthenModel 
                {
                    status = 200,
                    success = true,
                    data = data
                };
            }
            catch (Exception ex)
            {
                return new ResponseAuthenModel
                {
                    status = 500,
                    success = false,
                    message = "Login failed. Please enter a valid login name and password.",
                    error = ex.Message
                };
            }
        }

        private UserIdentityModel VerifyUserName(RequestAuthenModel model)
        {
            try
            {
                var authenData = _dataService.Get_AuthenData_By_Username(model.username);

                if (authenData == null)
                {
                    throw new ValidationException("Error verify usern");
                }
                else if (authenData.Count == 0)
                {
                    throw new ValidationException("Username is not found");
                }
                else if (authenData.Count > 1)
                {
                    throw new ValidationException("Username has more than 1 row");
                }

                // check status = A
                var userIdentity = authenData[0];
                if (userIdentity.status != "A")
                {
                    throw new ValidationException("Username is not active [" + userIdentity.status + "]");
                }
                else
                {
                    return userIdentity;
                }
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error verify username. " + ex.Message);
            }
        }

        private void VerifyPassword(UserIdentityModel userIdentity, string passwordInput)
        {
            try
            {
                if (userIdentity.password.Trim() != passwordInput.Trim())
                {
                    throw new ValidationException("Password incorrect");
                }
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error verify password. " + ex.Message);
            }
        }

        private ResultAuthenModel GetCustomerInfo(RequestAuthenModel model)
        {
            try
            {
                //var r = _httpConnect.GetAPI("http://localhost:5075/WeatherForecast");

                return new ResultAuthenModel 
                {
                    customerNumber = "10000001",
                    name = "Mr. Tanapoom Jaisabay",
                    customerStatus = "N"
                };
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error get customer infomation. " + ex.Message);
            }
        }

        private string GenrateUserToken(ResultAuthenModel custInfo, RequestAuthenModel model) 
        {
            try
            {
                TokenService tokenService = new TokenService(_configuration);

                RequestTokenModel data = new RequestTokenModel
                {
                    customerId = custInfo.customerNumber,
                    customerStatus = custInfo.customerStatus,
                    username = model.username
                };

                return tokenService.GenerateJwtToken(data);
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error generate user token. " + ex.Message);
            }
        }
    }
}
