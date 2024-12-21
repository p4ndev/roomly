namespace Server.Data.Dtos;

public record AuthenticationDto(
    string Token,
    string Role
);