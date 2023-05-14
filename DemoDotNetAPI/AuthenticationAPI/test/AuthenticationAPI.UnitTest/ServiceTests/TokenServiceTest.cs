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
    public class TokenServiceTest
    {
        private readonly TokenService _service;
        private readonly IConfigurationRoot _config;
        private readonly StubAppsetting _appsetting = new StubAppsetting();
        private readonly DateTime _transactionDate;

        public TokenServiceTest()
        {
            // load stub appsetting
            _config = new ConfigurationBuilder()
            .AddInMemoryCollection(_appsetting.LoadDataAppsetting())
            .Build();

            _transactionDate = DateTime.ParseExact("14/05/2565 12:30:45", "dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH", false));
            _service = new TokenService(_config);
        }

        [Fact]
        public void Case001_Flow_LoginUserPssword_Success()
        {
            RequestAuthenModel request = new RequestAuthenModel
            {
                username = "demotest",
                password = "aa112233",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };
            
            ResponseTokenModel response = _service.RequestToken(request);

            var expectedStatus = 200;
            var actualStatus = response.status;
            var expectedToken = true;
            var actualToken = (response.data.Length > 10 ? true : false);

            Assert.Equal(expectedStatus, actualStatus);
            Assert.Equal(expectedToken, actualToken);
        }

        [Fact]
        public void Case002_Flow_LoginUserPssword_Error_Invalid_Authen()
        {
            RequestAuthenModel request = new RequestAuthenModel
            {
                username = "user001",
                password = "Aa112233",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };

            ResponseTokenModel response = _service.RequestToken(request);

            var expectedStatus = 500;
            var actualStatus = response.status;
            var expectedMessage = "Failed request token. Please enter a valid data.";
            var actualMessage = response.message;
            var expectedError = "Invalid data.";
            var actualError = response.error;

            Assert.Equal(expectedStatus, actualStatus);
            Assert.Equal(expectedMessage, actualMessage);
            Assert.Equal(expectedError, actualError);
        }
    }
}
