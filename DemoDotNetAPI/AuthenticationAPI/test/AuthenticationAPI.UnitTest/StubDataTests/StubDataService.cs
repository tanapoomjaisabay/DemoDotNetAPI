using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAPI.UnitTest.StubDataTests
{
    public class StubDataService : IDataService
    {
        public List<UserIdentityModel> Get_AuthenData_By_Username(string username)
        {
            List<UserIdentityModel> response = new List<UserIdentityModel>();
            if (username == "tanapoom1993")
            {
                UserIdentityModel data = CreateResult(1, "1111100001", "tanapoom1993", "Aa112233", "A"); //success
                response.Add(data);
            }
            else if (username == "user001")
            {
                return response; //error not found data
            }
            else if (username == "user003")
            {
                UserIdentityModel data1 = CreateResult(3, "1110000003", "user03", "Aa112233", "A"); //error duplicate
                UserIdentityModel data2 = CreateResult(4, "1119900003", "user03", "Aa112233", "A");
                response.Add(data1);
                response.Add(data2);
            }
            else if (username == "user004")
            {
                UserIdentityModel data1 = CreateResult(5, "1110000004", "user04", "Aa112233", "D"); //error duplicate
                response.Add(data1);
            }
            else
            {
                UserIdentityModel data = CreateResult(1, "1111100001", username, "Aa112233", "A");
                response.Add(data);
            }

            return response;
        }

        private UserIdentityModel CreateResult(int idKey, string customerNumber, string username, string password, string status)
        {
            DateTime _dateTransaction = DateTime.ParseExact("14/05/2565 11:11:11", "dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH", false));
            return new UserIdentityModel
            {
                idKey = idKey,
                customerNumber = customerNumber,
                username = username,
                password = password,
                status = status,
                invalidPassword = 0,
                changePassword = 0,
                updateBy = "unittest",
                updateDatetime = _dateTransaction,
                createBy = "unittest",
                createDatetime = _dateTransaction,
            };
        }
    }
}
