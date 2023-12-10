using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Dto;
public record ResetPasswordQuery(
    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string NewPassword,

    [Required]
    string ConfirmNewPassword,

    [Required]
    string ResetCode
);