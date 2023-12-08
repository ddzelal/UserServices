using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Dto;
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
);
