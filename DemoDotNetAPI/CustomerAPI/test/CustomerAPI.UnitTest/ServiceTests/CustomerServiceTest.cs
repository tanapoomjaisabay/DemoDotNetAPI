using CustomerAPI.DataAccess;
using CustomerAPI.Models;
using CustomerAPI.Services;
using CustomerAPI.UnitTest.StubDataTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.UnitTest.ServiceTests
{
    public class CustomerServiceTest
    {
        private readonly CustomerService _service;
        private readonly IConfigurationRoot _config;
        private readonly StubAppsetting _appsetting = new StubAppsetting();
        private readonly CustomerInfoContext _context;
        private readonly DateTime _transactionDate;

        private readonly IConfigurationRoot _e1_config;
        private readonly CustomerService _e1_service;

        public CustomerServiceTest()
        {
            // load stub appsetting
            _config = new ConfigurationBuilder()
            .AddInMemoryCollection(_appsetting.LoadDataAppsetting())
            .Build();

            //load stub dataset
            string id = Guid.NewGuid().ToString();
            var contextMemory = new DbContextOptionsBuilder<CustomerInfoContext>().UseInMemoryDatabase(id)
               .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            _context = new CustomerInfoContext(contextMemory.Options);
            _context.LoadDataCustomerInfomation();

            _transactionDate = DateTime.ParseExact("14/05/2565 12:30:45", "dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH", false));
            _service = new CustomerService(_context);

            #region "For Error Case"
            _e1_config = new ConfigurationBuilder()
            .AddInMemoryCollection(_appsetting.InvalidAppsetting())
            .Build();
            _e1_service = new CustomerService(_context);
            #endregion
        }

        [Fact]
        public void Case001_Flow_GetCustomerInformation_Success()
        {
            RequestCustomerInfoModel request = new RequestCustomerInfoModel
            {
                customerNumber = "1111100001",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };
            
            ResponseCustomerInfoModel response = _service.GetCustomerInformation(request);

            var expectedStatus = 200;
            var actualStatus = response.status;
            var expectedName = "Tanapoom Jaisabay";
            var actualName = response.data.fullName;

            Assert.Equal(expectedStatus, actualStatus);
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void Case002_Flow_GetCustomerInformation_Error_NotFound()
        {
            RequestCustomerInfoModel request = new RequestCustomerInfoModel
            {
                customerNumber = "1111100003",
                deviceInfo = "UnitTest",
                transactionDate = _transactionDate
            };

            ResponseCustomerInfoModel response = _service.GetCustomerInformation(request);

            var expectedStatus = 500;
            var actualStatus = response.status;
            var expectedMessage = "Failed get customer infomation. Please try again.";
            var actualMessage = response.message;
            var expectedError = "Failed get customer infomation by CustomerNumber. Not found data";
            var actualError = response.error;

            Assert.Equal(expectedStatus, actualStatus);
            Assert.Equal(expectedMessage, actualMessage);
            Assert.Equal(expectedError, actualError);
        }
    }
}
