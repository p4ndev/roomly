using Server.Data.Dtos;
using Server.Data.Enums;

namespace Server.Data.Interfaces;

public interface SetupServiceInterface
{
    Task<bool>          ExistAsync(CancellationToken token = default);
    Task                ExposeAsync(CancellationToken token = default);
    Task<RoleEnum?>     FindAsync(string password, CancellationToken token = default);
    Task<bool>          InstallAsync(InstallationDto installationDto, AccessDto accessDto, CancellationToken token = default);
    bool                IsValid(InstallationDto? installationRequest);
    Task<AccessDto?>    LoadAsync(CancellationToken token = default);
    Task<byte[]?>       LogotypeAsync(CancellationToken token = default);
}