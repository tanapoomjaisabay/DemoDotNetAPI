using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperLIB.Service
{
    public interface IHttpConnectService
    {
        string PostAPI(string ip, string controller, string json);
        Task PostAPIAsync(string ip, string controller, string json);
        string GetAPI(string url);
        Task GetAPIAsync(string url); //test
    }
}
