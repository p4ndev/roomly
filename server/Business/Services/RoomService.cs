using Server.Business.Contexts;
using Server.Data.Interfaces;
using Server.Data.Entities;
using Server.Data.Dtos;

namespace Server.Business.Services;

public class RoomService(RelationalContext _relationalContext) : RoomServiceInterface
{
    public async Task<int?> CreateAsync(RoomDto model, CancellationToken token = default)
    {
        RoomEntity entity = new(model);

        await _relationalContext.Rooms.AddAsync(entity, token);

        if (await _relationalContext.SaveChangesAsync(token) >= 1)
            return entity.Id;

        return null;
    }

    public async Task<IList<RoomEntity>> ListAsync(CancellationToken token = default)
        => await _relationalContext.Rooms.AsNoTracking().OrderBy(r => r.Order).ToListAsync(token);
}