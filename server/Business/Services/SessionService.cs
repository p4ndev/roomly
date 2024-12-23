using Microsoft.AspNetCore.SignalR;
using Server.Data.Interfaces;
using Server.Data.Entities;

namespace Server.Business.Services;

public class SessionService(IHubContext<SessionService> _hubContext) : Hub, SessionServiceInterface
{
    public byte[]? Logotype { get; set; } = null;

    public async Task RoomAdded(RoomEntity entity)
        => await _hubContext.Clients.All.SendAsync("RoomAdded", entity);

    public async Task RoomUpdated(RoomEntity entity)
       => await _hubContext.Clients.All.SendAsync("RoomUpdated", entity);

    public async Task RoomRemoved(int entityId)
        => await _hubContext.Clients.All.SendAsync("RoomRemoved", entityId);
}