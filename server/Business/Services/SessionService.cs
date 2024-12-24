using Server.Data.Interfaces;

namespace Server.Business.Services;

public class SessionService : SessionServiceInterface
{
    public byte[]? Logotype { get; set; } = null;
}