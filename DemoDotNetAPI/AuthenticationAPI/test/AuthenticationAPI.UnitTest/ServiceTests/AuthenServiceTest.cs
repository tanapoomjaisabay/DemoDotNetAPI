using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using AuthenticationAPI.UnitTest.StubDataTests;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAPI.UnitTest.ServiceTests
{
    public class AuthenServiceTest
    {
        private readonly AuthenService _service;
        private readonly IConfigurationRoot _config;
        private readonly StubAppsetting _appsetting = new StubAppsetting();
        private readonly DateTime _transactionDate;

        private readonly IConfigurationRoot _e1_config;
        private readonly AuthenService _e1_service;

        public AuthenServiceTest()
        {
            // load stub appsetting
            _config = new ConfigurationBuilder()
            .AddInMemoryCollection(_appsetting.LoadDataAppsetting())
            .Build();

            _transactionDate = DateTime.ParseExact("14/05/2565 12:30:45", "dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH", false));
            _service = new AuthenService(_config, new StubHttpConnectService(), new StubDataService());

            #region "For Error Case"
            _e1_config = new ConfigurationBuilder()
            .AddInMemoryCollection(_appsetting.InvalidAppsetting())
            .Build();
            _e1_service = new AuthenService(_e1_config, new StubHttpConnectService(), new StubDataService());
            #endregion
        }

        [Fact]
        public void Case001_Flow_LoginUserPssword_Success()
        {
            RequestAuthenModel request = new RequestAuthenModel 
            {
                username = "tanapoom1993",
                password = "Aa112233",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };

            ResponseAuthenModel response = _service.LoginUserPssword(request);

            var expectedStatus = 200;
            var actualStatus = response.status;
            var expectedName = "Tanapoom";
            var actualName = response.status;

            Assert.Equal(expectedStatus, actualStatus);
        }

        [Fact]
        public void Case002_Flow_LoginUserPssword_Error_NotFound()
        {
            RequestAuthenModel request = new RequestAuthenModel
            {
                username = "user001",
                password = "Aa112233",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };

            ResponseAuthenModel response = _service.LoginUserPssword(request);

            var expectedStatus = 500;
            var actualStatus = response.status;
            var expectedMessage = "Login failed. Please enter a valid login name and password.";
            var actualMessage = response.message;
            var expectedError = "Error verify username. Username is not found";
            var actualError = response.error;

            Assert.Equal(expectedStatus, actualStatus);
            Assert.Equal(expectedMessage, actualMessage);
            Assert.Equal(expectedError, actualError);
        }

        [Fact]
        public void Case003_Flow_LoginUserPssword_Error_FoundData_Duplicate()
        {
            RequestAuthenModel request = new RequestAuthenModel
            {
                username = "user003",
                password = "Aa112233",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };

            ResponseAuthenModel response = _service.LoginUserPssword(request);

            var expectedStatus = 500;
            var actualStatus = response.status;
            var expectedMessage = "Login failed. Please enter a valid login name and password.";
            var actualMessage = response.message;
            var expectedError = "Error verify username. Username has more than 1 row";
            var actualError = response.error;

            Assert.Equal(expectedStatus, actualStatus);
            Assert.Equal(expectedMessage, actualMessage);
            Assert.Equal(expectedError, actualError);
        }

        [Fact]
        public void Case004_Flow_LoginUserPssword_Error_NotActive_Status()
        {
            RequestAuthenModel request = new RequestAuthenModel
            {
                username = "user004",
                password = "Aa112233",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };

            ResponseAuthenModel response = _service.LoginUserPssword(request);

            var expectedStatus = 500;
            var actualStatus = response.status;
            var expectedMessage = "Login failed. Please enter a valid login name and password.";
            var actualMessage = response.message;
            var expectedError = "Error verify username. Username is not active [D]";
            var actualError = response.error;

            Assert.Equal(expectedStatus, actualStatus);
            Assert.Equal(expectedMessage, actualMessage);
            Assert.Equal(expectedError, actualError);
        }

        [Fact]
        public void Case005_Flow_LoginUserPssword_Error_Incorrect_Password()
        {
            RequestAuthenModel request = new RequestAuthenModel
            {
                username = "tanapoom1993",
                password = "Aa445566",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };

            ResponseAuthenModel response = _service.LoginUserPssword(request);

            var expectedStatus = 500;
            var actualStatus = response.status;
            var expectedMessage = "Login failed. Please enter a valid login name and password.";
            var actualMessage = response.message;
            var expectedError = "Error verify password. Password incorrect";
            var actualError = response.error;

            Assert.Equal(expectedStatus, actualStatus);
            Assert.Equal(expectedMessage, actualMessage);
            Assert.Equal(expectedError, actualError);
        }

        [Fact]
        public void Case006_Flow_LoginUserPssword_Error_Get_CustomerInfo()
        {
            RequestAuthenModel request = new RequestAuthenModel
            {
                username = "user_8888810001",
                password = "Aa112233",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };

            ResponseAuthenModel response = _service.LoginUserPssword(request);

            var expectedStatus = 500;
            var actualStatus = response.status;
            var expectedMessage = "Login failed. Please enter a valid login name and password.";
            var actualMessage = response.message;
            var expectedError = "Error get customer infomation. InternalService has exception. Failed get customer infomation by CustomerNumber.";
            var actualError = response.error;

            Assert.Equal(expectedStatus, actualStatus);
            Assert.Equal(expectedMessage, actualMessage);
            Assert.Equal(expectedError, actualError);
        }

        [Fact]
        public void Case007_Flow_LoginUserPssword_Error_Get_CustomerInfo()
        {
            RequestAuthenModel request = new RequestAuthenModel
            {
                username = "user_8888810002",
                password = "Aa112233",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };

            ResponseAuthenModel response = _service.LoginUserPssword(request);

            var expectedStatus = 500;
            var actualStatus = response.status;
            var expectedMessage = "Login failed. Please enter a valid login name and password.";
            var actualMessage = response.message;
            var expectedError = "Error get customer infomation. Response is null";
            var actualError = response.error;

            Assert.Equal(expectedStatus, actualStatus);
            Assert.Equal(expectedMessage, actualMessage);
            Assert.Equal(expectedError, actualError);
        }


        #region "Miner"
        [Fact]
        public void Case101_GenrateUserToken_Error_Setup_Appsetting()
        {
            ResultAuthenModel custInfo = new ResultAuthenModel();
            UserIdentityModel userIdentity = new UserIdentityModel();

            string errorMessage;

            try
            {
                var response = _e1_service.GenrateUserToken(custInfo, userIdentity);
                errorMessage = "";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            string expectedMessage = "Error generate user token";
            string actualMessage = errorMessage.Split(".")[0].Trim();

            Assert.Equal(expectedMessage, actualMessage);
        }
        #endregion
    }
}
