using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperLIB.Service
{
    public static class ValidateService
    {
        //public static void ValidateServiceTime(DateTime? dateTransaction, ref string messageToCust)
        //{
        //    string startTime = _configuration["ServiceTime:Start"].ToString().Trim();
        //    string stopTime = _configuration["ServiceTime:Stop"].ToString().Trim();
        //    IsPeriodServiceTime(startTime, stopTime, dateTransaction, ref messageToCust);
        //}

        //public static void IsPeriodServiceTime(string startTime, string stopTime, DateTime? dateNow, ref string messageToCust)
        //{
        //    try
        //    {
        //        double dbNow = Convert.ToDouble(dateNow.HasValue ? dateNow.Value.ToString("HH.mm") : DateTime.Now.ToString("HH.mm"));

        //        double dbStart = 0.0;
        //        double dbStop = 0.0;
        //        if (startTime != "")
        //        {
        //            dbStart = Convert.ToDouble(startTime);
        //        }

        //        if (stopTime != "")
        //        {
        //            dbStop = Convert.ToDouble(stopTime);
        //        }

        //        if (dbNow < dbStart || dbNow > dbStop)
        //        {
        //            messageToCust = String.Format(_configuration["Message_ILMobileAPI:501"], startTime, stopTime);
        //            throw new ValidationException("Not Pass Criteria " + dbNow + "|" + dbStart + "|" + dbStop);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ValidationException("Error Check ServiceTime. " + ex.ToMessage());
        //    }
        //}

        public static void ValidateModelParam<T>(T model, ref string messageToCust)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, validationContext, results, true))
            {
                messageToCust = "Invalid data. Please try again.";
                throw new ValidationException("Failed validate parameter model. " + results.FirstOrDefault().ToString());
            }
        }
    }
}
