using AuthenticationAPI.DataAccess;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using AuthenticationAPI.UnitTest.StubDataTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAPI.UnitTest.ServiceTests
{
    public class DataServiceTest
    {
        private readonly DataService _service;
        private readonly CustomerAuthenContext _context;
        private readonly DateTime _transactionDate;

        public DataServiceTest()
        {
            //load stub dataset
            string id = Guid.NewGuid().ToString();
            var ILContract = new DbContextOptionsBuilder<CustomerAuthenContext>().UseInMemoryDatabase(id)
               .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            _context = new CustomerAuthenContext(ILContract.Options);
            _context.LoadDataCustomerAuthen();

            _transactionDate = DateTime.ParseExact("14/05/2565 12:30:45", "dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH", false));
            _service = new DataService(_context);
        }

        [Fact]
        public void Case001_Get_AuthenData_By_Username_Success()
        {
            string username = "tanapoom1993";

            List<UserIdentityModel> response = _service.Get_AuthenData_By_Username(username);

            var expected = "1111100001";
            var actual = response[0].customerNumber;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Case002_Get_AuthenData_By_Username_Error_ConnectDB()
        {
            string username = "user001";

            string errorMessage;

            try
            {
                #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                DataService _service2 = new DataService(null);
                #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                List<UserIdentityModel> response = _service2.Get_AuthenData_By_Username(username);
                errorMessage = "";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            string expectedMessage = "Failed get authentication data by Username";
            string actualMessage = errorMessage.Split(".")[0].Trim();

            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}
