using CustomerAPI.DataAccess;
using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static APIHelperLIB.Service.ValidateService;

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
            string errorMessage = "Failed get customer infomation. Please try again.";

            try
            {
                ValidateModelParam<RequestCustomerInfoModel>(model, ref errorMessage);

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
                    message = errorMessage,
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

                if (result == null)
                {
                    throw new ValidationException("Not found data");
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<ResultCustomerInfoModel>(JsonConvert.SerializeObject(result));
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
