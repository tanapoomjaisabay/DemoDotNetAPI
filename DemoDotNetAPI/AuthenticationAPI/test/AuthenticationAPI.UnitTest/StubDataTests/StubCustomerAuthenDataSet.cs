using AuthenticationAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAPI.UnitTest.StubDataTests
{
    public static class StubCustomerAuthenDataSet
    {
        public static void LoadDataCustomerAuthen(this CustomerAuthenContext context)
        {
            DateTime _dateTransaction = DateTime.ParseExact("14/05/2565 11:11:11", "dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH", false));
            context.authenEntity.AddRange(
                new CustAuthenEntity
                {
                    idKey = 1,
                    customerNumber = "1111100001", //success
                    username = "tanapoom1993",
                    password = "Aa112233",
                    status = "A",
                    invalidPassword = 0,
                    changePassword = 0,
                    updateBy = "unittest",
                    updateDatetime = _dateTransaction,
                    createBy = "unittest",
                    createDatetime = _dateTransaction,
                }, new CustAuthenEntity
                {
                    idKey = 2,
                    customerNumber = "1111100002", //success
                    username = "user002",
                    password = "Aa112233",
                    status = "A",
                    invalidPassword = 0,
                    changePassword = 0,
                    updateBy = "unittest",
                    updateDatetime = _dateTransaction,
                    createBy = "unittest",
                    createDatetime = _dateTransaction,
                }, new CustAuthenEntity
                {
                    idKey = 3,
                    customerNumber = "1111100003", //error duplicate
                    username = "user003",
                    password = "Aa112233",
                    status = "A",
                    invalidPassword = 0,
                    changePassword = 0,
                    updateBy = "unittest",
                    updateDatetime = _dateTransaction,
                    createBy = "unittest",
                    createDatetime = _dateTransaction,
                }, new CustAuthenEntity
                {
                    idKey = 4,
                    customerNumber = "1119900003", //error duplicate
                    username = "user003",
                    password = "Aa112233",
                    status = "A",
                    invalidPassword = 0,
                    changePassword = 0,
                    updateBy = "unittest",
                    updateDatetime = _dateTransaction,
                    createBy = "unittest",
                    createDatetime = _dateTransaction,
                }, new CustAuthenEntity
                {
                    idKey = 5,
                    customerNumber = "1111100004", //error status
                    username = "user004",
                    password = "Aa112233",
                    status = "D",
                    invalidPassword = 0,
                    changePassword = 0,
                    updateBy = "unittest",
                    updateDatetime = _dateTransaction,
                    createBy = "unittest",
                    createDatetime = _dateTransaction,
                }, new CustAuthenEntity
                {
                    idKey = 6,
                    customerNumber = "1111100005",
                    username = "user005",
                    password = "Aa445566",
                    status = "A",
                    invalidPassword = 0,
                    changePassword = 0,
                    updateBy = "unittest",
                    updateDatetime = _dateTransaction,
                    createBy = "unittest",
                    createDatetime = _dateTransaction,
                });
            context.SaveChanges();
        }
    }
}
