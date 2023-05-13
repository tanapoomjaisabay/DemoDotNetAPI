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
                string custId = VerifyUserName(model);
                VerifyPassword(model);
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

        private string VerifyUserName(RequestAuthenModel model)
        {
            try
            {
                _dataService.Get_AuthenData_By_Username("tanapoom1993");
                return "10000001";
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error verify username. " + ex.Message);
            }
        }

        private void VerifyPassword(RequestAuthenModel model)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error verify password. " + ex.Message);
            }
        }

        private ResultAuthenModel GetCustomerInfo(RequestAuthenModel model)
        {
            //call api
            try
            {
                var r = _httpConnect.GetAPI("http://localhost:5075/WeatherForecast");

                return new ResultAuthenModel 
                {
                    customerId = "10000001",
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
                    customerId = custInfo.customerId,
                    customerStatus = custInfo.customerStatus,
                    username = model.username
                };

                return tokenService.GenerateJwtToken(data);
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error genrate user token. " + ex.Message);
            }
        }
    }
}
