using PMT.Core.Enums;

namespace PMT.Core.Models;

public class Project
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public EProjectStatus Status { get; set; } =  EProjectStatus.NotStarted;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public long CreatedBy { get; set; }
    public decimal EstimatedHours { get; set; }
    public decimal ActualHours { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime CompetedAt { get; set; }

    public long ManagerId { get; set; }
    public Developer Manager { get; set; } = null!;
    
    public ICollection<ProjectDeveloper> ProjectDevelopers { get; set; } = null!;
    
    public ICollection<Task> Tasks { get; set; } = null!;
}