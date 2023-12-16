using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRepository.Dto;
using UserRepository.Models;

namespace UserRepository.Interfaces
{
    public interface IPostService
    {
        public Task CreatePost(PostCommand command);
        public Task DelatePost(int postId);

        // public Task<IEnumerable<Post>> GetPosts(int page, int pageSize, SortOrder sortOrder);

    }
}