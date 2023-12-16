using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserRepository.Data;
using UserRepository.Dto;
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

        public async Task DeletePost(int postId, int authorId)
        {
            var post = await _context.Post.FirstOrDefaultAsync(p => p.Id == postId && p.AuthorId == authorId);
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync() => _context.DisposeAsync();


        public async Task<Post?> GetPostById(int postId) => await _context.Post.Where(p => p.Id == postId).FirstOrDefaultAsync();



        public Task<List<PostsResponse>> GetPosts(GetPostsQuery getPostsQuery)
        {
            throw new NotImplementedException();
        }
    }
}