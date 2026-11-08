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
            .ValueGeneratedNever();

        builder.Property(p => p.CreatedAtUtc)
            .HasColumnName("created_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
        
        builder.Property(p => p.UpdatedAtUtc)
            .HasColumnName("created_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
        
        builder.Property(p => p.Status)
            .HasColumnName("status")
            .HasColumnType("integer")
            .IsRequired();
        
        builder
            .Property(x => x.PetId)
            .HasColumnName("pet_id");
        
        builder
            .Property(x => x.ApplicantId)
            .HasColumnName("user_id");
        
        builder
            .HasOne(p => p.Pet)
            .WithMany(p => p.AdoptionApplications)
            .HasForeignKey(p => p.PetId)
            .IsRequired();
        
        builder
            .HasOne(p => p.Applicant)
            .WithMany()
            .HasForeignKey(p => p.ApplicantId)
            .IsRequired();
    }
}