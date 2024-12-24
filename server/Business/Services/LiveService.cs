using Microsoft.AspNetCore.SignalR;
using Server.Data.Interfaces;
using Server.Data.Entities;

namespace Server.Business.Services;

public class LiveService(IHubContext<LiveService> _hubContext) : Hub, LiveServiceInterface
{
    public async Task RoomAdded(RoomEntity entity)
        => await _hubContext.Clients.All.SendAsync("RoomAdded", entity);

    public async Task RoomUpdated(RoomEntity entity)
       => await _hubContext.Clients.All.SendAsync("RoomUpdated", entity);

    public async Task RoomRemoved(int entityId)
        => await _hubContext.Clients.All.SendAsync("RoomRemoved", entityId);
}