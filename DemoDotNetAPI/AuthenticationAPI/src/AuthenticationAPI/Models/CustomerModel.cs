namespace AuthenticationAPI.Models
{
    public class CustomerMasterInfoModel
    {
        public string customerNumber { get; set; } = string.Empty;
        public string idCardNumber { get; set; } = string.Empty;
        public string fullName { get; set; } = string.Empty;
        public string birthDate { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public string mobileNumber { get; set; } = string.Empty;
        public string? email { get; set; }
        public string status { get; set; } = string.Empty;
    }

    public class RequestCustomerInfoModel
    {
        public string customerNumber { get; set; } = string.Empty;
    }
}
