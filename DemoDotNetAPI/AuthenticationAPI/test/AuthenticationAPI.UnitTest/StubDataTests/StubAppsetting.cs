using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAPI.UnitTest.StubDataTests
{
    class StubAppsetting
    {
        public Dictionary<string, string> LoadDataAppsetting()
        {
            Dictionary<string, string> arrayDict = new Dictionary<string, string>
            {
                {"Logging:LogLevel:Default","Warning"},
                {"AllowedHosts","*" },

                {"JWT:securityKey","DvmC7mm7yqa4Rqp6zxRhBgJ8CHFg3"},
                {"JWT:issuer","https://www.google.com"},
                {"JWT:expiresMinutes","120"},

                {"MessageResponse:Activated","ขออภัยค่ะ ท่านทำการยืนยันการใช้งานผ่านอีเมลฉบับนี้เรียบร้อบแล้ว"},
        };
            return arrayDict;
        }
    }
}
