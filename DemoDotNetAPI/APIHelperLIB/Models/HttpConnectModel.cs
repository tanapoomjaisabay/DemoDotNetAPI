using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperLIB.Models
{
    public class ResponseHttpConnectModel
    {
        public int status { get; set; }
        public bool success { get; set; }
        public string message { get; set; } = string.Empty;
        public object? error { get; set; }
        public object? data { get; set; }
    }

    public class RequestModel
    {
        public string deviceInfo { get; set; } = string.Empty;
        public DateTime transactionDate { get; set; }
    }

    public class ResponseModel
    {
        public int status { get; set; }
        public bool success { get; set; }
        public string message { get; set; } = string.Empty;
        public object? error { get; set; }
    }
}
