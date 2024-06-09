using APBD_10.Entities.Config;
using Microsoft.EntityFrameworkCore;

namespace APBD_10.Entities;

public class MusicDbContext : DbContext
{
    public DbSet<Muzyk> Muzycy { get; set; }
    public DbSet<Utwor> Utwory { get; set; }
    public DbSet<Album> Albumy { get; set; }
    public DbSet<Wytwornia> Wytwornie { get; set; }
    public DbSet<WykonawcaUtworu> WykonawcyUtworow { get; set; }

    public MusicDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MuzykEFConfig).Assembly);
    }
}
