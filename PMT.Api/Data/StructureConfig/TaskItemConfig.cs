using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMT.Core.Enums;
using PMT.Core.Models;

namespace PMT.Api.Data.StructureConfig;

public class TaskItemConfig : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.ToTable("TaskItem");
        
        builder.Property(t => t.Id)
            .IsRequired(true)
            .ValueGeneratedOnAdd()
            .HasColumnType("BIGINT");
        
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Title)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(200);
        
        builder.Property(t => t.Description)
            .IsRequired(false)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(2000);

        builder.Property(t => t.Status)
            .IsRequired(true)
            .HasColumnType("TINYINT")
            .HasDefaultValue(ETaskStatus.Unassigned);

        builder.Property(t => t.CreatedAt)
            .IsRequired(true)
            .HasColumnType("DATETIME2");
        
        builder.Property(t => t.CreatedBy)
            .IsRequired(true)
            .HasColumnType("BIGINT");
        
        builder.Property(t => t.EstimatedHours)
            .IsRequired(false)
            .HasColumnType("INT");
        
        builder.Property(t => t.ActualHours)
            .IsRequired(false)
            .HasColumnType("INT");
        
        builder.Property(t => t.StartedAt)
            .IsRequired(false)
            .HasColumnType("DATETIME2");
        
        builder.Property(t => t.CompletedAt)
            .IsRequired(false)
            .HasColumnType("DATETIME2");
        
        builder.Property(t => t.ProjectId)
            .IsRequired(true)
            .HasColumnType("BIGINT");
        
        builder.Property(t => t.DeveloperId)
            .IsRequired(false)
            .HasColumnType("BIGINT");
        
        builder.HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(t => t.Developer)
            .WithMany(d => d.Tasks)
            .HasForeignKey(t => t.DeveloperId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasIndex(t => t.Title)
            .IsUnique(false)
            .HasDatabaseName("IDX_TASK_TITLE");
        
        builder.HasIndex(t => t.Status)
            .IsUnique(false)
            .HasDatabaseName("IDX_TASK_STATUS");
    }
}