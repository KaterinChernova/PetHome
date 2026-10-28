using Microsoft.EntityFrameworkCore;
using PetHome.Entities;

namespace PetHome.DataBase;

public class PetHomeDbContext : DbContext
{
    public PetHomeDbContext(DbContextOptions options)
        : base(options)
    {
        
    }
    
    public DbSet<PetEntity> Pets { get; set; }
    public DbSet<AdoptionApplicationEntity> Applications { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<PetEntity>()
        //     .ToTable("pets")
        //     .HasKey(p => p.Id);
        //
        // modelBuilder.ApplyConfiguration(new PetPropertiesConfiguration());
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetPropertiesConfiguration).Assembly);
        // modelBuilder.Entity<PetEntity>()
        //     .Property(p => p.Id)
        //     .ValueGeneratedNever();
        //
        // modelBuilder.Entity<PetEntity>()
        //     .Property(p => p.Name)
        //     .HasColumnName("name")
        //     .HasMaxLength(100)
        //     .IsRequired();
        //
        // modelBuilder.Entity<PetEntity>()
        //     .Property(p => p.Description)
        //     .HasColumnName("description")
        //     .HasMaxLength(1000);
        //
        // modelBuilder.Entity<PetEntity>()
        //     .Property(p => p.Gender)
        //     .HasColumnName("gender")
        //     .IsRequired();
        //
        // modelBuilder.Entity<PetEntity>()
        //     .Property(p => p.Age)
        //     .HasColumnName("age")
        //     .IsRequired();
    }
}