using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserRepository.Dto;
using UserRepository.Interfaces;
using UserRepository.Models;

namespace UserRepository.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterInputType request)
        {
            RegisterCommand command = new(request.FirstName, request.LastName, request.Email, request.Password);

            await _authenticationService.Register(command);

            return Ok("Successfully register. We are send verification code in your mail, plase verified!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            LoginQuery loginQuery = new(request.Email, request.Password);

            AuthenticationResult result = await _authenticationService.Login(loginQuery);

            return Ok(result);
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Verfy([FromQuery] VerifyQuery request)
        {
            VerifyQuery verifyQuery = new(request.Email, request.VerificationCode);

            await _authenticationService.VerifyAccount(verifyQuery.Email, verifyQuery.VerificationCode);

            return Ok("User successfully verified!");
        }
    }
}