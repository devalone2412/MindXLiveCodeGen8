using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindXLiveCodeGen8.Domain.Interfaces.Services;

namespace MindXLiveCodeGen8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(string userName, string password)
        {
            try
            {
                var isSuccess = await _authenticationService.SignUp(userName, password);

                if (isSuccess)
                {
                    return Ok("Created account successfully");
                }
                
                return BadRequest("Created account fail!");
            }
            catch (Exception e)
            {
                return BadRequest("Some errors occurs when signing up the account");
            }
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            try
            {
                var token = await _authenticationService.Login(userName, password);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest("Login fail!");
            }
        }
    }
}
