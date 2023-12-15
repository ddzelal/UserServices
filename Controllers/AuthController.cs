using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPatch("verify")]
        public async Task Verfy([FromQuery] VerifyQuery request)
        {
            VerifyQuery verifyQuery = new(request.Email, request.VerificationCode);

            await _authenticationService.VerifyAccount(verifyQuery.Email, verifyQuery.VerificationCode);

            Ok("User successfully verified!");
        }

        [HttpPatch("reset-verification-code/{email}")]
        public async Task ResetVerificationCode(string email)
        {
            await _authenticationService.ResetVerificationCode(email);

            Ok("Successfully reset code!");
        }

        [HttpPatch("forgot-password-code/{email}")]
        public async Task ForgotPasswordSendCode(string email)
        {
            await _authenticationService.ForgotPasswordSendCode(email);

            Ok("Successfully send reset code!");
        }


        [HttpPut("reset-password")]
        public async Task ResetPassword([FromBody] ResetPasswordQuery resetPasswordQuery)
        {
            Console.WriteLine(resetPasswordQuery);
            await _authenticationService.ResetPassword(resetPasswordQuery.Email, resetPasswordQuery.NewPassword, resetPasswordQuery.ConfirmNewPassword, resetPasswordQuery.ResetCode);

            Ok("Successfully reset password!");
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            GetMeResault result = await _authenticationService.GetUserById();

            return Ok(result);

        }
    }
}