using Server.Data.Entities;

namespace Server.Business.Contexts;

public class RelationalContext : DbContext
{
    public DbSet<SettingEntity> Settings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "roomly.db");
        options.UseSqlite($"Data Source={file}");
    }
}