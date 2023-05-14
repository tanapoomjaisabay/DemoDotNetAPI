using APIHelperLIB.Models;
using APIHelperLIB.Service;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using AuthenticationAPI.APIHelper;
using static APIHelperLIB.Service.ValidateService;

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
            string errorMessage = "Login failed. Please enter a valid login name and password.";

            try
            {
                ValidateModelParam<RequestAuthenModel>(model, ref errorMessage);

                // verify username and password
                UserIdentityModel userIdentity = VerifyUserName(model);
                VerifyPassword(userIdentity, model.password);

                // get customer infomation and user jwt token
                var data = GetCustomerInfo(userIdentity);
                data.token = GenrateUserToken(data, userIdentity);

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
                    message = errorMessage,
                    error = ex.Message
                };
            }
        }

        private UserIdentityModel VerifyUserName(RequestAuthenModel model)
        {
            try
            {
                var authenData = _dataService.Get_AuthenData_By_Username(model.username);

                if (authenData.Count == 0)
                {
                    throw new ValidationException("Username is not found");
                }
                else if (authenData.Count > 1)
                {
                    throw new ValidationException("Username has more than 1 row");
                }

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

        private ResultAuthenModel GetCustomerInfo(UserIdentityModel model)
        {
            try
            {
                RequestCustomerInfoModel request = new RequestCustomerInfoModel 
                {
                    customerNumber = model.customerNumber
                };
                
                var content = _httpConnect.PostAPI(_configuration["CustomerService:URL"], "/Customer/GetInformation", JsonConvert.SerializeObject(request));
                var response = JsonConvert.DeserializeObject<ResponseHttpConnectModel>(content);
                var result = VerifyCustomerInfoResult(response);

                return new ResultAuthenModel
                {
                    customerNumber = model.customerNumber,
                    idCardNumber = result.idCardNumber,
                    name = result.fullName,
                    birthDate = result.birthDate,
                    gender = result.gender,
                    mobileNumber = result.mobileNumber,
                    customerStatus = result.status
                };
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error get customer infomation. " + ex.Message);
            }
        }

        private CustomerMasterInfoModel VerifyCustomerInfoResult(ResponseHttpConnectModel? response)
        {
            if (response == null)
            {
                throw new ValidationException("Response is null");
            }
            else if (response.status != 200)
            {
                throw new ValidationException("InternalService has exception. " + response.error.ToText());
            }
            else
            {
                var result = JsonConvert.DeserializeObject<CustomerMasterInfoModel>(JsonConvert.SerializeObject(response.data));
                //var a = response.data.MapValue<CustomerMasterInfoModel>();
                return result;
            }
        }

        public string GenrateUserToken(ResultAuthenModel custInfo, UserIdentityModel userIdentity) 
        {
            try
            {
                TokenService tokenService = new TokenService(_configuration);

                RequestTokenModel data = new RequestTokenModel
                {
                    customerNumber = custInfo.customerNumber,
                    customerStatus = custInfo.customerStatus,
                    username = userIdentity.username
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
