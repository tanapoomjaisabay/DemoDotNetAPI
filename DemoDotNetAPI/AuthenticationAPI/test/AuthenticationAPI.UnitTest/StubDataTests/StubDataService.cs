using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAPI.UnitTest.StubDataTests
{
    public class StubDataService : IDataService
    {
        public List<UserIdentityModel> Get_AuthenData_By_Username(string username)
        {
            throw new NotImplementedException();
        }
    }
}
