using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Dto;

namespace UserRepository.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResult> Login(LoginQuery query);
        public Task<AuthenticationResult> Register(RegisterCommand command);
        public Task VerifyAccount(string email, string verificationCode);
        public Task ResetVerificationCode(string email);
        public Task ForgotPasswordSendCode(string email);
        public Task ResetPassword(string email, string password, string confirmPassword, string resetCode);
    }
}