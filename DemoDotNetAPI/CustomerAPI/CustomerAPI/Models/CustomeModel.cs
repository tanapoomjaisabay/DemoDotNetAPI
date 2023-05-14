using APIHelperLIB.Models;
using CustomerAPI.DataAccess;

namespace CustomerAPI.Models
{
    public class RequestCustomerInfoModel : RequestModel
    {
        public string customerNumber { get; set; } = string.Empty;
        public string idCardNUmber { get; set; } = string.Empty;
    }

    public class ResponseCustomerInfoModel : ResponseModel
    {
        public ResultCustomerInfoModel? data { get; set; }
    }

    public class ResultCustomerInfoModel : CustomerInfoModel
    {
        public string fullName { get; set; } = string.Empty;
    }

    public class CustomerInfoModel : CustomerMasterInfoEntity
    {
    }
}
