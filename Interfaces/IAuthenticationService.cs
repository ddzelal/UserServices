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
    }
}