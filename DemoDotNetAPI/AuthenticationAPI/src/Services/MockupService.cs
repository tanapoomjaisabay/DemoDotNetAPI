using AuthenticationAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Services
{
    public class MockupService
    {
        private string VerifyUserName(RequestAuthenModel model)
        {
            return "10000001";
        }

        private void VerifyPassword(RequestAuthenModel model)
        {
            
        }

        private ResultAuthenModel GetCustomerInfo(RequestAuthenModel model)
        {
            return new ResultAuthenModel
            {
                customerNumber = "10000001",
                name = "Mr. Tanapoom Jaisabay",
                customerStatus = "N"
            };
        }
    }
}
