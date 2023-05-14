using CustomerAPI.Models;
using CustomerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public ResponseCustomerInfoModel GetInformation(RequestCustomerInfoModel model)
        {
            ResponseCustomerInfoModel response = _customerService.GetCustomerInformation(model);
            return response;
        }
    }
}
