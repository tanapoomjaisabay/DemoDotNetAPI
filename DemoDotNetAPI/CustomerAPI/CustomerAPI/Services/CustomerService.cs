using CustomerAPI.DataAccess;
using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext customerDb;

        public CustomerService(CustomerDbContext _customerDb) 
        {
            customerDb = _customerDb;
        }

        public ResponseCustomerInfoModel GetCustomerInformation(RequestCustomerInfoModel model)
        {
            try
            {

                var data = SELECT_CUSTOMER_INFO();

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

        private ResultCustomerInfoModel? SELECT_CUSTOMER_INFO()
        {
            try
            {
                var custInfo = customerDb.custInfoEntity;

                var result = (from tb in custInfo where tb.custId == 0 && tb.customerNumber == "" select tb).FirstOrDefault();
                ResultCustomerInfoModel? data = JsonConvert.DeserializeObject<ResultCustomerInfoModel>(JsonConvert.SerializeObject(result));
                return data;
            }
            catch (Exception ex)
            {
                throw new ValidationException(ex.Message);
            }
        }
    }
}
