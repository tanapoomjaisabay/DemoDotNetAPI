using AuthenticationAPI.DataAccess;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AuthenticationAPI.Services
{
    public class DataService : IDataService
    {
        private readonly CustomerAuthenContext _context;

        public DataService(CustomerAuthenContext context)
        {
            _context = context;
        }

        public List<UserIdentityModel> Get_AuthenData_By_Username(string username)
        {
            try
            {
                var ent = _context.authenEntity;

                var result = (from d in ent
                              where d.username == username
                              select d).ToList();

                var data = JsonConvert.DeserializeObject<List<UserIdentityModel>>(JsonConvert.SerializeObject(result));
                return data;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Failed get authentication data by Username. " + ex.Message);
            }
        }
    }
}
