using Server.Data.Entities;

namespace Server.Data.Interfaces;

public interface LiveServiceInterface
{
    Task RoomAdded(RoomEntity entity);
    Task RoomRemoved(int entityId);
    Task RoomUpdated(RoomEntity entity);
}
