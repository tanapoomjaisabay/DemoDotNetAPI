using CustomerAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.DataAccess
{
    public class CustomerMasterInfoEntity
    {
        [Column("idKey")]
        public int idKey { get; set; }
        [Column("customerNumber")]
        public string customerNumber { get; set; } = string.Empty;
        [Column("idCardNumber")]
        public string idCardNumber { get; set; } = string.Empty;
        [Column("nameTH")]
        public string nameTH { get; set; } = string.Empty;
        [Column("surnameTH")]
        public string surnameTH { get; set; } = string.Empty;
        [Column("nameEN")]
        public string nameEN { get; set; } = string.Empty;
        [Column("surnameEN")]
        public string surnameEN { get; set; } = string.Empty;
        [Column("birthDate")]
        public string birthDate { get; set; } = string.Empty;
        [Column("gender")]
        public string gender { get; set; } = string.Empty;
        [Column("mobileNumber")]
        public string mobileNumber { get; set; } = string.Empty;
        [Column("email")]
        public string? email { get; set; }
        [Column("status")]
        public string status { get; set; } = string.Empty;
        [Column("updateBy")]
        public string updateBy { get; set; } = string.Empty;
        [Column("updateDatetime")]
        public DateTime? updateDatetime { get; set; }
        [Column("createBy")]
        public string createBy { get; set; } = string.Empty;
        [Column("createDatetime")]
        public DateTime createDatetime { get; set; }
    }
}
