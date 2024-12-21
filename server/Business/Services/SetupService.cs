using Server.Business.Contexts;
using Server.Data.Interfaces;
using Server.Data.Entities;
using Server.Data.Enums;
using Server.Data.Dtos;

namespace Server.Business.Services;

public class SetupService(RelationalContext _relationalContext) : SetupServiceInterface
{
    private readonly string _placeholder = "data:image/png;base64,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";

    public async Task<bool> ExistAsync(CancellationToken token = default)
        => await _relationalContext.Settings.AsNoTracking().AnyAsync(token);

    public async Task ExposeAsync(CancellationToken token = default)
    {
        var entity = await _relationalContext.Settings.FirstOrDefaultAsync(token);

        if (entity is null)
            return;

        entity.Expose();

        await _relationalContext.SaveChangesAsync(token);
    }

    public async Task<RoleEnum?> FindAsync(string password, CancellationToken token = default)
    {
        SettingEntity? entity = await _relationalContext
            .Settings
            .AsNoTracking()
                .FirstOrDefaultAsync(s => 
                    s.Viewer.Equals(password)           ||
                    s.Coordinator.Equals(password)      ||
                    s.Administrator.Equals(password),
                    token
                );

        return entity switch
        {
            {   Viewer        : var viewer              }   when viewer.Equals(password)            => RoleEnum.Viewer,
            {   Coordinator   : var coordinator         }   when coordinator.Equals(password)       => RoleEnum.Coordinator,
            {   Administrator : var administrator       }   when administrator.Equals(password)     => RoleEnum.Administrator,
            _ => null
        };
    }

    public async Task<bool> InstallAsync(InstallationDto installationDto, AccessDto accessDto, CancellationToken token = default)
    {
        var entity = new SettingEntity(installationDto, accessDto);

        await _relationalContext.Settings.AddAsync(entity, token);

        return (await _relationalContext.SaveChangesAsync(token) >= 1);
    }

    public bool IsValid(InstallationDto? installationRequest)
    {
        if (installationRequest is null                         ||
            String.IsNullOrEmpty(installationRequest.Name)      ||
            String.IsNullOrEmpty(installationRequest.Logotype)
        )   return false;
        return true;
    }

    public async Task<AccessDto?> LoadAsync(CancellationToken token = default)
    {
        var entity = await _relationalContext
            .Settings
            .AsNoTracking()
                .FirstOrDefaultAsync(
                    s => s.Shown.Equals(false),
                    token
                );

        if (entity is null)
            return null;

        return new AccessDto(entity.Viewer, entity.Coordinator, entity.Administrator);
    }

    public async Task<byte[]?> LogotypeAsync(CancellationToken token = default)
    {
        try
        {
            var output = await _relationalContext
                .Settings
                .AsNoTracking()
                .Select(s => s.Logotype)
                    .FirstOrDefaultAsync(token);

            string imageBase64Source = (output ?? _placeholder).Replace("data:image/png;base64,", "");

            return Convert.FromBase64String(imageBase64Source);
        }
        catch (Exception)
        {
            return null;
        }
    }
}