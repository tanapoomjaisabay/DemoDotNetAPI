using CustomerAPI.Models;

namespace CustomerAPI.DataAccess
{
    public class CustomerInfoEntity : CustomerInfoModel
    {
        public string createBy { get; set; } = string.Empty;
        public DateTime? createDateTime { get; set; }
        public string updateBy { get; set; } = string.Empty;
        public DateTime? updateDateTime { get; set; }
    }
}
