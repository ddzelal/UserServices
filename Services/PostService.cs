using System.Security.Claims;
using UserRepository.Dto;
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
    }
}