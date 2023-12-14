
namespace UserRepository.Dto;
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
);
