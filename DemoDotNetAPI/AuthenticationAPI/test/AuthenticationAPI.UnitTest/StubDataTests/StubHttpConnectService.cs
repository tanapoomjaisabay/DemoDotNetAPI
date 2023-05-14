using APIHelperLIB.Service;
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
            throw new NotImplementedException();
        }

        public Task PostAPIAsync(string ip, string controller, string json)
        {
            throw new NotImplementedException();
        }
    }
}
