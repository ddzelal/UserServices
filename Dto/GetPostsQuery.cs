using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UserRepository.Dto
{
    public record GetPostsQuery(
        string? SearchTerm,
        string? SortOrder,
        int? Page,
        int? PageSize
    ) : IRequest<PageList<PostsResponse>>;

    public record PostsResponse(
    int Id,
    string Title,
    string Content
    // public DateTime CreatedAt { get; set; } = DateTime.Now;

    // [ForeignKey("AuthorId")]
    // public User Author { get; set; } = null!;
    // public int AuthorId { get; set; }
    );

}