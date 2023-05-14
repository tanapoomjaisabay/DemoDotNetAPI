using CustomerAPI.Models;

namespace CustomerAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        ResponseCustomerInfoModel GetCustomerInformation(RequestCustomerInfoModel model);
    }
}
