using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShortLink.Models;

namespace ShortLink.Apis.Auth
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/auth")]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginParam loginParam)
        {
            AccountModel accountModel = await _authService.Login(loginParam);
            
            return Ok(accountModel);
        }
        
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterParam registerParam)
        {
            AccountModel accountModel = await _authService.Register(registerParam);
            
            return Ok(accountModel);
        }
    }
}