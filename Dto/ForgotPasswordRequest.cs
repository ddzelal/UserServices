using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Dto;

public record ForgotPasswordRequest(

    [Required]
    [EmailAddress]
    string Email
);
