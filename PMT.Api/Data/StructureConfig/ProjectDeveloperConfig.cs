using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMT.Core.Models;

namespace PMT.Api.Data.StructureConfig;

public class ProjectDeveloperConfig : IEntityTypeConfiguration<ProjectDeveloper>
{
    public void Configure(EntityTypeBuilder<ProjectDeveloper> builder)
    {
        builder.ToTable("ProjectDeveloper");
        
        builder.Property(pd => pd.ProjectId)
            .IsRequired(true)
            .HasColumnType("BIGINT");
        
        builder.Property(pd => pd.DeveloperId)
            .IsRequired(true)
            .HasColumnType("BIGINT");
        
        builder.HasKey(pd => new { pd.ProjectId, pd.DeveloperId });
        
        builder.Property(pd => pd.JoinedAt)
            .IsRequired(true)
            .HasColumnType("DATETIME2");
        
        builder.HasOne(pd => pd.Project)
            .WithMany(p => p.ProjectDevelopers)
            .HasForeignKey(pd => pd.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(pd => pd.Developer)
            .WithMany(d => d.ProjectDevelopers)
            .HasForeignKey(pd => pd.DeveloperId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}