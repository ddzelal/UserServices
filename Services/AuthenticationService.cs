using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Dto;
using UserRepository.Errors;
using UserRepository.Interfaces;
using UserRepository.Models;

namespace UserRepository.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ICodeGenerator _codeGenerator;
        private readonly IEmailService _emailService;
        public AuthenticationService(IUserRepository userRepository, IPasswordHasher passwordHasher, ICodeGenerator codeGenerator, IEmailService emailService)
        {
            _emailService = emailService;
            _codeGenerator = codeGenerator;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;

        }

        public async Task ForgotPasswordSendCode(string email)
        {
            Console.WriteLine(email);
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new NoUserFoundException("User not found");
            }
            var resetPasswordCode = _codeGenerator.GenerateResetPasswordCode();
            user.ResetPasswordCode = resetPasswordCode;

            _emailService.SendResetCode(email, resetPasswordCode);

            await _userRepository.Update(user);

        }

        public async Task<AuthenticationResult> Login(LoginQuery query)
        {
            if (await _userRepository.GetByEmail(query.Email) is not User user)
            {
                throw new BadRequestException("Wrong password or email.");
            }
            if (!user.IsVerified)
            {
                throw new BadRequestException("User is not verified.");
            }
            if (!_passwordHasher.Verify(user.Password, query.Password))
            {
                throw new BadRequestException("Wrong password or email.");
            }

            return new AuthenticationResult(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email
            );
        }

        public async Task<AuthenticationResult> Register(RegisterCommand command)
        {
            if (await _userRepository.GetByEmail(command.Email) is not null)
            {
                throw new BadRequestException("User already exist");
            }

            string passwordHash = _passwordHasher.HashPassword(command.Password);

            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = passwordHash,
                VerificationCode = _codeGenerator.GenerateVerificationCode()

            };

            _emailService.SendVerificationCode(user.Email, user.VerificationCode);

            await _userRepository.Add(user);


            return new AuthenticationResult(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email
            );
        }

        public async Task ResetPassword(string email, string newPassword, string confirmNewPassword, string resetCode)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new NoUserFoundException("User not found");
            }
            if (newPassword != confirmNewPassword)
            {
                throw new BadRequestException("Passwords do not match. Please make sure your password and confirmation match.");
            }
            if (user.ResetPasswordCode != resetCode)
            {
                throw new BadRequestException("Invalid code");
            }
            user.Password = _passwordHasher.HashPassword(newPassword);
            user.ResetPasswordCode = null;

            await _userRepository.Update(user);
        }

        public async Task ResetVerificationCode(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new NoUserFoundException("User not found");
            }
            var verificationCode = _codeGenerator.GenerateVerificationCode();
            user.VerificationCode = verificationCode;
            _emailService.SendVerificationCode(email, verificationCode);
            await _userRepository.Update(user);

        }

        public async Task VerifyAccount(string email, string verificationCode)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new NoUserFoundException("User not found");
            }

            if (user.VerificationCode != verificationCode) throw new BadRequestException("Invalid verification code");

            user.IsVerified = true;

            await _userRepository.Update(user);
        }
    }
}