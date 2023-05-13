namespace AuthenticationAPI.Models
{
    public class RequestAuthenModel : RequestModel
    {
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

    public class ResponseAuthenModel : ResponseModel
    {
        public ResultAuthenModel? data { get; set; }
    }

    public class ResultAuthenModel
    {
        public string customerNumber { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string customerStatus { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
    }

    public class ResponseTokenModel : ResponseModel
    {
        public string data { get; set; } = string.Empty;
    }

    public class RequestTokenModel
    {
        public string username { get; set; } = string.Empty;
        public string customerId { get; set; } = string.Empty;
        public string customerStatus { get; set; } = string.Empty;
    }
}
