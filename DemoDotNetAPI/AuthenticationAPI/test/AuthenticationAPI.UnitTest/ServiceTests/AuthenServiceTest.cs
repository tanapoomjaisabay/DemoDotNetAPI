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

        public AuthenServiceTest()
        {
            // load stub appsetting
            _config = new ConfigurationBuilder()
            .AddInMemoryCollection(_appsetting.LoadDataAppsetting())
            .Build();

            _transactionDate = DateTime.ParseExact("14/05/2565 12:30:45", "dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH", false));
            _service = new AuthenService(_config, new StubHttpConnectService(), new StubDataService());
        }

        [Fact]
        public void Case001_LoginUserPssword_Success()
        {
            RequestAuthenModel request = new RequestAuthenModel 
            {
                username = "username",
                password = "password",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };

            ResponseAuthenModel response = _service.LoginUserPssword(request);

            var expected = 200;
            var actual = response.status;

            Assert.Equal(expected, actual);
        }
    }
}
