using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMT.Core.Models;

namespace PMT.Api.Data.StructureConfig;

public class DeveloperConfig : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.ToTable("Developer");
        
        builder.Property(d => d.Id)
            .IsRequired(true)
            .ValueGeneratedOnAdd()
            .HasColumnType("BIGINT");
        
        builder.HasKey(d => d.Id);
        
        builder.Property(d => d.Name)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(200);
        
        builder.Property(d => d.IsActive)
            .IsRequired(true)
            .HasColumnType("BIT")
            .HasDefaultValue(true);
        
        builder.HasIndex(d => d.IsActive)
            .IsUnique(false)
            .HasDatabaseName("IDX_DEVELOPER_ACTIVE");
    }
}