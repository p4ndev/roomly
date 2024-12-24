using Server.Data.Entities;
using Server.Data.Dtos;

namespace Server.Data.Interfaces;

public interface RoomServiceInterface
{
    Task<RoomEntity?> CreateAsync(RoomDto model, CancellationToken token = default);
    Task<IList<RoomEntity>> ListAsync(CancellationToken token = default);
}