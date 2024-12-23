using Server.Data.Entities;

namespace Server.Data.Interfaces;

public interface SessionServiceInterface
{
    byte[]? Logotype { get; set; }

    Task RoomAdded(RoomEntity entity);
    Task RoomRemoved(int entityId);
    Task RoomUpdated(RoomEntity entity);
}