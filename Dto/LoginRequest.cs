using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public record LoginRequest(
    string Email,
    string Password
);
