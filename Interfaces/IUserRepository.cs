using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Models;

namespace UserRepository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetByEmail(string email);
        public Task<User?> GetUserById(int userId);
        public Task Add(User user);
        Task Update(User user);

    }
}