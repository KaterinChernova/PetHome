using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHome.Entities;

namespace PetHome.DataBase;

public class PetPropertiesConfiguration: IEntityTypeConfiguration<PetEntity>
{
    public void Configure(EntityTypeBuilder<PetEntity> builder)
    {
        builder.ToTable("pets");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Breed)
            .HasColumnName("breed")
            .HasConversion<string>()
            .HasMaxLength(200)
            .IsRequired();
                
        builder.Property(p => p.Kind)
            .HasColumnName("kind")
            .HasConversion<int>()
            .IsRequired();
        
        builder.Property(p => p.Gender)
            .HasColumnName("gender")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(p => p.DateOfBirth)
            .HasColumnName("date_of_birth")
            .HasConversion<DateTime>()
            .IsRequired();
        
        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(p => p.Status)
            .HasColumnName("status")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(p => p.RegisteredDate)
            .HasColumnName("registered_at_utc")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }
}