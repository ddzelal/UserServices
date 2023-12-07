using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Models;

namespace UserRepository.Interfaces
{
    public interface IUserRepository
    {
        bool IsUserExist(string email);
        bool IsUserVerified(int userId);
        User GetUserById(int userId);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool Save();

    }
}