using MediatR;

namespace UserRepository.Dto;
public record GetPostsQuery(
    string? SearchTerm,
    string? SortOrder,
    int? Page,
    int? PageSize
) : IRequest<PageList<PostsResponse>>;
