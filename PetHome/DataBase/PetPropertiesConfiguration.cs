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
    }
}