using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserRepository.Data;
using UserRepository.Interfaces;
using UserRepository.Models;


namespace UserRepository.Repository
{
    public class UserRepository : IUserRepository, IAsyncDisposable
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;

        }

        public async Task Add(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}