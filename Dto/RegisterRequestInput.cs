using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Models;

public record RegisterInputType(
    string FirstName,
    string LastName,
    string Email,
    string Password
);
