using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService() { }

        public ResponseCustomerInfoModel GetCustomerInformation(RequestCustomerInfoModel model)
        {
            try
            {
                
                return new ResponseCustomerInfoModel
                {
                    status = 200,
                    success = true,
                    data = new ResultCustomerInfoModel 
                    { 
                        custId = 1,
                        customerNumber = "11111111",
                        name = ""
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseCustomerInfoModel
                {
                    status = 500,
                    success = false,
                    message = "Get customer data failed. Please try again.",
                    error = ex.Message
                };
            }
        }
    }
}
