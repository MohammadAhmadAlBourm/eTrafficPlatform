using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class TrafficContext(DbContextOptions<TrafficContext> options) : DbContext(options)
{
    public DbSet<Traffic> Traffics { get; set; }
    public DbSet<TrafficEvent> TrafficEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Traffic>()
            .HasKey(x => x.SessionID);

        modelBuilder.Entity<TrafficEvent>()
        .HasKey(x => x.Id);


        modelBuilder.Entity<Traffic>()
            .HasMany(o => o.TrafficEvents)
            .WithOne(oi => oi.Traffic)
            .HasForeignKey(oi => oi.SessionID);
    }
}