using Server.Data.Entities;

namespace Server.Data.Interfaces;

public interface LiveServiceInterface
{
    Task RoomAddedAsync(RoomEntity entity);
}
