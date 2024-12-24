using Server.Data.Dtos;
using Server.Data.Entities;

namespace Server.Data.Interfaces;

public interface RoomServiceInterface
{
    Task<int?> CreateAsync(RoomDto model, CancellationToken token = default);
    Task<IList<RoomEntity>> ListAsync(CancellationToken token = default);
}