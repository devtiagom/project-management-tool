using PMT.Core.Enums;

namespace PMT.Core.Models;

public class Task
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ETaskStatus Status { get; set; } =  ETaskStatus.Unassigned;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public long CreatedBy { get; set; }
    public decimal EstimatedHours { get; set; }
    public decimal ActualHours { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime CompetedAt { get; set; }
    
    public long ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    
    public long DeveloperId { get; set; }
    public Developer Developer { get; set; } = null!;
}