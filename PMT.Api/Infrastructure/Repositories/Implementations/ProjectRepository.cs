using System.Linq.Expressions;
using PMT.Api.Infrastructure.Data.Context;
using PMT.Api.Infrastructure.Repositories.Base;
using PMT.Core.Contracts.Repositories;
using PMT.Core.Enums;
using PMT.Core.Models;

namespace PMT.Api.Infrastructure.Repositories.Implementations;

public class ProjectRepository(AppDbContext context) : BaseRepository<Project>(context), IProjectRepository
{
    public Task<IEnumerable<Project>> GetByTitleAsync(string title)
    {
        Expression<Func<Project, bool>> projectTitleLikePredicate = project => project.Title.Contains(title);
        return FindAsync(projectTitleLikePredicate);
    }

    public Task<IEnumerable<Project>> GetByStatusAsync(EProjectStatus status)
    {
        Expression<Func<Project, bool>> projectStatusPredicate = project => project.Status == status;
        return FindAsync(projectStatusPredicate);
    }
}