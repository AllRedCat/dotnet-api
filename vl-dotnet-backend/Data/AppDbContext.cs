using Microsoft.EntityFrameworkCore;
using vl_dotnet_backend.Models;

namespace vl_dotnet_backend.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Users> Users { get; set; }
    public DbSet<ParkingLots> ParkingLots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParkingLots>()
            .Property(p => p.OperationalSchedule)
            .HasColumnType("json");
    }
}