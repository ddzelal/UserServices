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
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task Verfy([FromQuery] VerifyQuery request)
        {
            VerifyQuery verifyQuery = new(request.Email, request.VerificationCode);

            await _authenticationService.VerifyAccount(verifyQuery.Email, verifyQuery.VerificationCode);

            Ok("User successfully verified!");
        }

        [HttpPost("reset-verification-code/{email}")]
        public async Task ResetVerificationCode([FromBody] string Email)
        {
            await _authenticationService.ResetVerificationCode(Email);

            Ok("Successfully reset code!");
        }

        [HttpPost("forgot-password-code/{email}")]
        public async Task ForgotPasswordSendCode([FromQuery] string email)
        {
            await _authenticationService.ForgotPasswordSendCode(email);

            Ok("Successfully send reset code!");
        }
    }
}