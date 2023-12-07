using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Data;
using UserRepository.Interfaces;
using UserRepository.Models;

namespace UserRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;

        }
        public bool CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            return _context.User.Where(u => u.Id == userId).FirstOrDefault();
        }

        public bool IsUserExist(string email)
        {
            return _context.User.Any(u => u.Email == email);

        }

        public bool IsUserVerified(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}