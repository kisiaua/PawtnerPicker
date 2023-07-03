using Microsoft.EntityFrameworkCore;
using PawtnerPicker.Models.Domain;

namespace PawtnerPicker.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Authentication> Authentications { get; set; } = null!;

    public DbSet<Breed> Breeds { get; set; } = null!;
    public DbSet<GroomingFrequency> GroomingFrequencies { get; set; } = null!;
    public DbSet<Shedding> Sheddings { get; set; } = null!;
    public DbSet<EnergyLevel> EnergyLevels { get; set; } = null!;
    public DbSet<Trainability> Trainabilities { get; set; } = null!;
    public DbSet<Demeanor> Demeanors { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Breed>()
            .HasOne(b => b.GroomingFrequency)
            .WithMany()
            .HasForeignKey(b => b.GroomingFrequencyValue);

        modelBuilder.Entity<Breed>()
            .HasOne(b => b.Shedding)
            .WithMany()
            .HasForeignKey(b => b.SheddingValue);

        modelBuilder.Entity<Breed>()
            .HasOne(b => b.EnergyLevel)
            .WithMany()
            .HasForeignKey(b => b.EnergyLevelValue);

        modelBuilder.Entity<Breed>()
            .HasOne(b => b.Trainability)
            .WithMany()
            .HasForeignKey(b => b.TrainabilityValue);

        modelBuilder.Entity<Breed>()
            .HasOne(b => b.Demeanor)
            .WithMany()
            .HasForeignKey(b => b.DemeanorValue);
    }
}