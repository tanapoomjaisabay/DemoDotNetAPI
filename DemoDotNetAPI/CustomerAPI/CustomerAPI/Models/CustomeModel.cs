using APIHelperLIB.Models;

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

    public class CustomerInfoModel
    {
        public int custId { get; set; }
        public string customerNumber { get; set; } = string.Empty;
        public string idCardNumber { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public string birthDate { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public string mobileNumber { get; set; } = string.Empty;
        public string customerStatus { get; set; } = string.Empty;
    }
}
