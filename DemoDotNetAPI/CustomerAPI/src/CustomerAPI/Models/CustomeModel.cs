using APIHelperLIB.Models;
using CustomerAPI.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Models
{
    public class RequestCustomerInfoModel : RequestModel
    {
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Customer Number is invalid")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please specify your customer number")]
        [StringLength(10, ErrorMessage = "Customer Number is invalid")]
        public string customerNumber { get; set; } = string.Empty;
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
