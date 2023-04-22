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
}
