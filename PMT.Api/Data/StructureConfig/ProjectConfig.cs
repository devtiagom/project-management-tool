using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMT.Core.Enums;
using PMT.Core.Models;

namespace PMT.Api.Data.StructureConfig;

public class ProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Project");
        
        builder.Property(p => p.Id)
            .IsRequired(true)
            .ValueGeneratedOnAdd()
            .HasColumnType("BIGINT");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Title)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(200);
        
        builder.Property(p => p.Description)
            .IsRequired(false)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(2000);

        builder.Property(p => p.Status)
            .IsRequired(true)
            .HasColumnType("TINYINT")
            .HasDefaultValue(EProjectStatus.NotStarted);

        builder.Property(p => p.CreatedAt)
            .IsRequired(true)
            .HasColumnType("DATETIME2");
        
        builder.Property(p => p.CreatedBy)
            .IsRequired(true)
            .HasColumnType("BIGINT");
        
        builder.Property(p => p.EstimatedHours)
            .IsRequired(false)
            .HasColumnType("INT");
        
        builder.Property(p => p.ActualHours)
            .IsRequired(false)
            .HasColumnType("INT");
        
        builder.Property(p => p.StartedAt)
            .IsRequired(false)
            .HasColumnType("DATETIME2");
        
        builder.Property(p => p.CompletedAt)
            .IsRequired(false)
            .HasColumnType("DATETIME2");
        
        builder.Property(p => p.ManagerId)
            .IsRequired(true)
            .HasColumnType("BIGINT");
        
        builder.HasOne(p => p.Manager)
            .WithMany(d => d.ManagedProjects)
            .HasForeignKey(p => p.ManagerId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(d => d.Title)
            .IsUnique(false)
            .HasDatabaseName("IDX_PROJECT_TITLE");
        
        builder.HasIndex(d => d.Status)
            .IsUnique(false)
            .HasDatabaseName("IDX_PROJECT_STATUS");
    }
}