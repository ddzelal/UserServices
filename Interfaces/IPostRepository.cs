using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Models;

namespace UserRepository.Interfaces
{
    public interface IPostRepository
    {
        public Task Add(Post post);
        public Task<Post?> GetPostById(int postId);

        public Task DeletePost(int postId, int authorId);

    }
}