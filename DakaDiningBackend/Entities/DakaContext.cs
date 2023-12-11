using Microsoft.EntityFrameworkCore;

namespace DakaDiningBackend.Entities;

public class DakaContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<SessionEntity> Sessions { get; set; }
    public DbSet<RequestEntity> Requests { get; set; }
    public DbSet<OfferEntity> Offers { get; set; }

    public string DbPath { get; }

    public DakaContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasMany(user => user.Requests)
            .WithOne(request => request.RequestedBy)
            .HasForeignKey(request => request.RequestedById);
        modelBuilder.Entity<UserEntity>()
            .HasMany(user => user.RequestsFilled)
            .WithOne(request => request.FilledBy)
            .HasForeignKey(request => request.FilledById);

        // Offers
        modelBuilder.Entity<UserEntity>()
            .HasMany(user => user.Offers)
            .WithOne(offer => offer.OfferedBy)
            .HasForeignKey(offer => offer.OfferedById);
        modelBuilder.Entity<UserEntity>()
            .HasMany(user => user.OffersFilled)
            .WithOne(offer => offer.PurchasedBy)
            .HasForeignKey(offer => offer.PurchasedById);
    }
}
