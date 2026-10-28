using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHome.Entities;

namespace PetHome.DataBase;

public class AdoptionApplicationPropertiesConfiguration: IEntityTypeConfiguration<AdoptionApplicationEntity>
{
    public void Configure(EntityTypeBuilder<AdoptionApplicationEntity> builder)
    {
        builder.ToTable("adoption_application");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(p => p.Status)
            .HasColumnName("status")
            .HasColumnType("integer")
            .IsRequired();
        
        builder
            .Property(x => x.PetId)
            .HasColumnName("pet_id");
        
        builder
            .Property(x => x.UserId)
            .HasColumnName("user_id");
        
        builder
            .HasOne(p => p.Pet)
            .WithMany(p => p.AdoptionApplications)
            .HasForeignKey(p => p.PetId)
            .IsRequired();
        
        builder
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .IsRequired();
    }
}