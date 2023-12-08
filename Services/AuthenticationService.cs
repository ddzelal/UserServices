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
        public AuthenticationService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;

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
                Password = passwordHash
            };

            await _userRepository.Add(user);

            return new AuthenticationResult(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email
            );
        }
    }
}