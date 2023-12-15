using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Dto;
public record GetMeResault(
    int Id,
    string FirstName,
    string LastName,
    string Emai);
