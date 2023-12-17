using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Dto;
public record PostsResponse(
int Id,
string Title,
string Content,
DateTime CreatedAt,
int AuthorId
);