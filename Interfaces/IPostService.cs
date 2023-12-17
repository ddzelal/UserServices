
using UserRepository.Dto;

namespace UserRepository.Interfaces
{
    public interface IPostService
    {
        public Task CreatePost(PostCommand command);
        public Task DelatePost(int postId);
        Task<PageList<PostsResponse>> GetPosts(GetPostsQuery request);


    }
}