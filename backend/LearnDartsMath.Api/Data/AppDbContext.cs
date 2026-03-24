using LearnDartsMath.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnDartsMath.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<PlayerProfile> PlayerProfiles => Set<PlayerProfile>();
    public DbSet<TrainingSession> TrainingSessions => Set<TrainingSession>();
    public DbSet<TurnEntry> TurnEntries => Set<TurnEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
            .Property(u => u.PasswordHash)
            .IsRequired();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<PlayerProfile>()
            .Property(p => p.DisplayName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<PlayerProfile>()
            .HasOne(p => p.User)
            .WithOne(u => u.PlayerProfile)
            .HasForeignKey<PlayerProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TrainingSession>()
            .Property(t => t.Mode)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<TrainingSession>()
            .HasOne(t => t.User)
            .WithMany(u => u.TrainingSessions)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TurnEntry>()
            .HasOne(te => te.TrainingSession)
            .WithMany(ts => ts.TurnEntries)
            .HasForeignKey(te => te.TrainingSessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}