namespace Server.Data.Dtos;

public record AccessDto(
    [Required] string Viewer,
    [Required] string Coordinator,
    [Required] string Administrator
);