namespace PMT.Core.Models;

public class Developer
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public ICollection<Project> ManagedProjects { get; set; } = null!;
    
    public ICollection<ProjectDeveloper> ProjectDevelopers { get; set; } = null!;
    
    public ICollection<TaskItem> Tasks { get; set; } = null!;
}