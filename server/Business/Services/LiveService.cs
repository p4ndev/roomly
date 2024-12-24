using Microsoft.AspNetCore.SignalR;
using Server.Data.Interfaces;
using Server.Data.Entities;

namespace Server.Business.Services;

public class LiveService(IHubContext<LiveService> _hubContext) : Hub, LiveServiceInterface
{
    public async Task RoomAddedAsync(RoomEntity entity)
        => await _hubContext.Clients.All.SendAsync("RoomAdded", entity);
}