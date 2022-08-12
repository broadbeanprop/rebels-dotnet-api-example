using Microsoft.EntityFrameworkCore;
using Rebels.ExampleProject.Data.Entities;

namespace Rebels.ExampleProject.Data;

public class DataContext : DbContext
{
    public DbSet<Rebel> Rebels { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        // Use memory if nothing else is defined
        optionsBuilder.UseInMemoryDatabase("ExampleProject");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder
            .Entity<Rebel>()
            .HasData(
                new Rebel() { Name = "Ezra Bridger" },
                new Rebel() { Name = "Kanan Jarrus" },
                new Rebel() { Name = "Hera Syndulla" },
                new Rebel() { Name = "Sabine Wren" },
                new Rebel() { Name = "Garazeb \"Zeb\" Orrelios" },
                new Rebel() { Name = "Chopper" }
            );
    }
}
