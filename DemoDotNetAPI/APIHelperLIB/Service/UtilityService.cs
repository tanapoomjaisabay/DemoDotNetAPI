using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperLIB.Service
{
    public static class UtilityService
    {
        public static string ToMessage(this Exception ex)
        {
            string message = ex.Message;
            try
            {
                if (ex.InnerException != null)
                {
                    message += ", [Internal : " + ex.InnerException.Message + "]";
                }
            }
            catch { }
            return message;
        }

        public static string ToText(this object? text)
        {
            string message = "";
            try
            {
                if (text == null)
                {
                    message = "";
                }
                else
                {
                    message = text.ToString().Trim();
                }
            }
            catch { }
            return message;
        }

        public static void TrimStringObject(this object model)
        {
            try
            {
                // Get all string properties of the model
                var stringProperties = model.GetType().GetProperties()
                    .Where(p => p.PropertyType == typeof(string));

                // Trim the value of each string property
                foreach (var prop in stringProperties)
                {
                    var value = (string)prop.GetValue(model);
                    if (value != null)
                    {
                        prop.SetValue(model, value.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed TrimStringObject. " + ex.Message);
            }
        }
    }
}
