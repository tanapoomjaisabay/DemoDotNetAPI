using APIHelperLIB.Models;
using APIHelperLIB.Service;
using AuthenticationAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAPI.UnitTest.StubDataTests
{
    public class StubHttpConnectService : IHttpConnectService
    {
        public string GetAPI(string url)
        {
            throw new NotImplementedException();
        }

        public Task GetAPIAsync(string url)
        {
            throw new NotImplementedException();
        }

        public string PostAPI(string ip, string controller, string json)
        {
            ResponseHttpConnectModel? response = new ResponseHttpConnectModel();
            string responseJson = "";

            if (controller.IndexOf("/Customer/GetInformation") != -1)
            {
                var result = new CustomerMasterInfoModel();
                var request = JsonConvert.DeserializeObject<RequestCustomerInfoModel>(json);
                if (request.customerNumber == "1111100001")
                {
                    result.customerNumber = "1111100001";
                    result.idCardNumber = "1639800146777";
                    result.fullName = "Tanapoom Jaisabay";
                    result.birthDate = "15/10/2536";
                    result.gender = "M";
                    result.mobileNumber = "0801122777";
                    result.email = "test@gmail.com";
                    result.status = "Y";

                    response.data = result;
                }
                else if (request.customerNumber == "8888810001")
                {
                    response = new ResponseHttpConnectModel 
                    {
                        status = 500,
                        message = "Failed get customer infomation. Please try again.",
                        error = "Failed get customer infomation by CustomerNumber."
                    };
                    responseJson = JsonConvert.SerializeObject(response);
                    return responseJson;
                }
                else if (request.customerNumber == "8888810002")
                {
                    response = null;
                    responseJson = JsonConvert.SerializeObject(response);
                    return responseJson;
                }
                else
                {
                    result.customerNumber = "1111100099";
                    result.idCardNumber = "1639800146999";
                    result.fullName = "Mockup Tester";
                    result.birthDate = "15/10/2536";
                    result.gender = "M";
                    result.mobileNumber = "0801122777";
                    result.email = "test@gmail.com";
                    result.status = "Y";

                    response.data = result;
                }
            }
            else 
            {
                throw new Exception("Incorrectly formatted URLs");
            }

            response.status = 200;
            response.success = true;
            responseJson = JsonConvert.SerializeObject(response);
            return responseJson;
        }

        public Task PostAPIAsync(string ip, string controller, string json)
        {
            throw new NotImplementedException();
        }
    }
}
