using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Dto;
public record AuthenticationResult(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);
