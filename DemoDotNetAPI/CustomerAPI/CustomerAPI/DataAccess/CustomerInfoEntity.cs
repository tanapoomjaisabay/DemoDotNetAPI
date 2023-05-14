using CustomerAPI.Models;

namespace CustomerAPI.DataAccess
{
    public class CustomerMasterInfoEntity
    {
        public int idKey { get; set; }
        public string customerNumber { get; set; } = string.Empty;
        public string idCardNumber { get; set; } = string.Empty;
        public string nameTH { get; set; } = string.Empty;
        public string surnameTH { get; set; } = string.Empty;
        public string nameEN { get; set; } = string.Empty;
        public string surnameEN { get; set; } = string.Empty;
        public string birthDate { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public string mobileNumber { get; set; } = string.Empty;
        public string? email { get; set; }
        public string status { get; set; } = string.Empty;
        public string updateBy { get; set; } = string.Empty;
        public DateTime? updateDatetime { get; set; }
        public string createBy { get; set; } = string.Empty;
        public DateTime createDatetime { get; set; }
    }
}
