namespace PMT.Core.Models;

public class ProjectDeveloper
{
    public long ProjectId { get; set; }
    public Project Project { get; set; } = null!;

    public long DeveloperId { get; set; }
    public Developer Developer { get; set; } = null!;
}