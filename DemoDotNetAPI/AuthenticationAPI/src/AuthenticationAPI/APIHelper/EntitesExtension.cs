using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.APIHelper
{
    public static class EntitesExtension
    {
        public static List<T> MapValue<T>(this object _iQuery)
        {

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Formatting = Formatting.None,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            string json = JsonConvert.SerializeObject(_iQuery, settings);
            var data = JsonConvert.DeserializeObject<List<T>>(json);

            if (data == null)
            {
                throw new ValidationException("MapValue result is null");
            }
            else
            {
                return data;
            }
        }
    }
}
