using System.Security.Claims;
using UserRepository.Dto;
using UserRepository.Errors;
using UserRepository.Interfaces;
using UserRepository.Models;

namespace UserRepository.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IGetClaim _getClaim;
        private readonly ClaimsPrincipal _claims;

        public PostService(IPostRepository postRepository, IGetClaim getClaim, ClaimsPrincipal claims)
        {
            _claims = claims;
            _getClaim = getClaim;
            _postRepository = postRepository;

        }
        public async Task CreatePost(PostCommand command)
        {
            int authorId = _getClaim.GetUserIdFromClaims(_claims);

            var post = new Post
            {
                Content = command.Content,
                Title = command.Title,
                AuthorId = authorId
            };

            await _postRepository.Add(post);
        }


        public async Task DelatePost(int postId)
        {
            int authorId = _getClaim.GetUserIdFromClaims(_claims);
            var post = await _postRepository.GetPostById(postId);

            if (post is null) throw new NotFoundRequestException("Not found post");
            if (post.AuthorId != authorId) throw new BadRequestException("You must be creator of post!");

            await _postRepository.DeletePost(post.Id, authorId);
        }
    }
}