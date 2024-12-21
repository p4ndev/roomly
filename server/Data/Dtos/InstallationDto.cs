namespace Server.Data.Dtos;

public record InstallationDto(
    [Required] string Name,
    [Required] string Logotype
);