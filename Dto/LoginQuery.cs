using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public record LoginQuery(
    string Email,
    string Password
);