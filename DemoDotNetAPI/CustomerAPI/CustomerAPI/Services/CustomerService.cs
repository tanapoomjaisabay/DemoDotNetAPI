using CustomerAPI.DataAccess;
using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerInfoContext customerDb;

        public CustomerService(CustomerInfoContext _customerDb) 
        {
            customerDb = _customerDb;
        }

        public ResponseCustomerInfoModel GetCustomerInformation(RequestCustomerInfoModel model)
        {
            try
            {

                ResultCustomerInfoModel data = Get_CustomerInfomation_By_CustNumber(model.customerNumber);
                data.fullName = GetFullNameCustomer(data);

                return new ResponseCustomerInfoModel
                {
                    status = 200,
                    success = true,
                    data = data
                };
            }
            catch (Exception ex)
            {
                return new ResponseCustomerInfoModel
                {
                    status = 500,
                    success = false,
                    message = "Failed get customer infomation. Please try again.",
                    error = ex.Message
                };
            }
        }

        private ResultCustomerInfoModel Get_CustomerInfomation_By_CustNumber(string customerNumber)
        {
            try
            {
                var ent = customerDb.custMasterInfoEntity;

                var result = (from tb in ent 
                              where tb.customerNumber == customerNumber 
                              select tb).FirstOrDefault();
                var data = JsonConvert.DeserializeObject<ResultCustomerInfoModel>(JsonConvert.SerializeObject(result));
                if (data == null)
                {
                    throw new ValidationException("Data is null");
                }
                else
                {
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new ValidationException("Failed get customer infomation by CustomerNumber. " + ex.Message);
            }
        }

        private string GetFullNameCustomer(ResultCustomerInfoModel data)
        {
            return data.nameEN + " " + data.surnameEN;
        }
    }
}
