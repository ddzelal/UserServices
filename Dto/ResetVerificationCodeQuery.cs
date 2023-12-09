using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRepository.Dto;
public record ResetVerificationCodeQuery(
    string email
);