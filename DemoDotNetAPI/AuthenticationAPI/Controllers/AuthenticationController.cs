using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using AuthenticationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenService _authenService;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IAuthenService authenService, ITokenService tokenService)
        {
            _authenService = authenService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public ResponseTokenModel RequestToken(RequestAuthenModel model)
        {
            ResponseTokenModel response = _tokenService.RequestToken(model);
            return response;
        }

        [HttpPost]
        [Authorize]
        public ResponseAuthenModel Login(RequestAuthenModel model)
        {
            ResponseAuthenModel response = _authenService.LoginUserPssword(model);
            return response;
        }
    }
}
