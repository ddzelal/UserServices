using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Dto
{
    public record GetPostsQuery(
        string? SortOrder,
        int? Page,
        int? PageSize
    );

    public record PostsResponse();

}