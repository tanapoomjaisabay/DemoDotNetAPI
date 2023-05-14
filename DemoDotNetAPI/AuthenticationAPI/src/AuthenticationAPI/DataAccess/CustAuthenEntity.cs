using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationAPI.DataAccess
{
    public class CustAuthenEntity
    {
        [Column("idKey")]
        public int idKey { get; set; }
        [Column("customerNumber")]
        public string customerNumber { get; set; } = string.Empty;
        [Column("username")]
        public string username { get; set; } = string.Empty;
        [Column("password")]
        public string password { get; set; } = string.Empty;
        [Column("status")]
        public string status { get; set; } = "D";
        [Column("invalidPassword")]
        public int invalidPassword { get; set; }
        [Column("changePassword")]
        public int changePassword { get; set; }
        [Column("updateBy")]
        public string? updateBy { get; set; } = string.Empty;
        [Column("updateDatetime")]
        public DateTime? updateDatetime { get; set; }
        [Column("createBy")]
        public string createBy { get; set; } = string.Empty;
        [Column("createDatetime")]
        public DateTime createDatetime { get; set; }
    }
}
