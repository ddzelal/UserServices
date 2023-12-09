using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public record LoginRequest(

    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string Password
);
