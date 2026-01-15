using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PMT.Core.Models;

namespace PMT.Api.Data;

public class AppDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<Developer> Developers { get; set; } = null!;
    public DbSet<TaskItem> Tasks { get; set; } = null!;
    public DbSet<ProjectDeveloper> ProjectDevelopers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}