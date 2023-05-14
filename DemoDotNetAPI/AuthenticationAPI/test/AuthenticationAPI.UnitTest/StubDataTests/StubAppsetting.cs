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

                {"MessageResponse:Activated","ขออภัยค่ะ ท่านทำการยืนยันการใช้งานผ่านอีเมลฉบับนี้เรียบร้อบแล้ว"},
                {"MessageResponse:Invalid","ขออภัยค่ะ ท่านระบุข้อมูลไม่ถูกต้อง กรุณาลองใหม่อีกครั้ง"},
                {"MessageResponse:NotFound","ขออภัยค่ะ ไม่พบข้อมูล ในระบบ"},

                {"Message:IB290:01","ผ่าน"},
        };
            return arrayDict;
        }
    }
}
