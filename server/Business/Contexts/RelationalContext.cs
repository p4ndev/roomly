using Server.Data.Entities;

namespace Server.Business.Contexts;

public class RelationalContext : DbContext
{
    public DbSet<SettingEntity>         Settings            { get; set; }
    public DbSet<RoomEntity>            Rooms               { get; set; }
    public DbSet<AmenityEntity>         Amenities           { get; set; }
    public DbSet<RoomAmenityEntity>     RoomAmenities       { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "roomly.db");
        options.UseSqlite($"Data Source={file}");
    }
}