using AuthenticationAPI.DataAccess;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Services
{
    public class DataService : IDataService
    {
        private readonly CustomerAuthenContext _context;

        public DataService(CustomerAuthenContext context)
        {
            _context = context;
        }

        public CustAuthenModel Get_AuthenData_By_Username(string username)
        {
            try
            {
                var ent = _context.authenEntity;

                var result = (from d in ent
                              where d.username == username
                              select d).ToList();

                // check list > 0 && list = 1
                // check status = A

                return null;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Failed get authentication data by Username. " + ex.Message);
            }
        }
    }
}
