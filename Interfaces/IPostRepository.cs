using UserRepository.Data;
using UserRepository.Dto;
using UserRepository.Models;

namespace UserRepository.Interfaces
{
    public interface IPostRepository
    {
        public Task Add(Post post);
        public Task<Post?> GetPostById(int postId);

        public Task DeletePost(int postId, int authorId);

        // public Task<IEnumerable<Post>> GetPosts(int page, int pageSize, SortOrder sortOrder);

        public Task<List<PostsResponse>> GetPosts(GetPostsQuery getPostsQuery);

    }
}