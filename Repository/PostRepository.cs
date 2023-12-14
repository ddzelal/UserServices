using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Data;
using UserRepository.Interfaces;
using UserRepository.Models;

namespace UserRepository.Repository
{
    public class PostRepository : IPostRepository, IAsyncDisposable
    {

        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;

        }
        public async Task Add(Post post)
        {
            await _context.Post.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();

        }
    }
}