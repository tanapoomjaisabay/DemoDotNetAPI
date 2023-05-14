using CustomerAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.UnitTest.StubDataTests
{
    public static class StubCustomerInfoDataSet
    {
        public static void LoadDataCustomerInfomation(this CustomerInfoContext context)
        {
            DateTime _dateTransaction = DateTime.ParseExact("14/05/2565 11:11:11", "dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH", false));
            context.custMasterInfoEntity.AddRange(
                new CustomerMasterInfoEntity
                {
                    idKey = 1,
                    customerNumber = "1111100001",
                    idCardNumber = "1111258804660",
                    nameTH = "ธนภูมิ",
                    surnameTH = "ใจสบาย",
                    nameEN = "Tanapoom",
                    surnameEN = "Jaisabay",
                    birthDate = "25361015",
                    gender = "M",
                    mobileNumber = "0801122777",
                    email = "test@gmail.com",
                    status = "Y",
                    updateBy = "unittest",
                    updateDatetime = _dateTransaction,
                    createBy = "unittest",
                    createDatetime = _dateTransaction
                }, new CustomerMasterInfoEntity
                {
                    idKey = 2,
                    customerNumber = "1111100002", //success
                    idCardNumber = "7143805865411",
                    nameTH = "ทดสอบ",
                    surnameTH = "ไอพี่ไอ",
                    nameEN = "Test",
                    surnameEN = "API",
                    birthDate = "25361020",
                    gender = "M",
                    mobileNumber = "0801122888",
                    email = "test@gmail.com",
                    status = "Y",
                    updateBy = "unittest",
                    updateDatetime = _dateTransaction,
                    createBy = "unittest",
                    createDatetime = _dateTransaction
                });
            context.SaveChanges();
        }
    }
}
