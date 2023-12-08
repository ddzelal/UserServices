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
            _context.Add(user);
            return Save();
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
            var user = _context.User.FirstOrDefault(u => u.Id == userId);
            return user != null && user.IsVerified;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }
    }
}