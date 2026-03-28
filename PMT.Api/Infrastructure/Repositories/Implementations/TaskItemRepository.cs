using System.Linq.Expressions;
using PMT.Api.Infrastructure.Data.Context;
using PMT.Api.Infrastructure.Repositories.Base;
using PMT.Core.Contracts.Repositories;
using PMT.Core.Enums;
using PMT.Core.Models;

namespace PMT.Api.Infrastructure.Repositories.Implementations;

public class TaskItemRepository(AppDbContext context) : BaseRepository<TaskItem>(context), ITaskItemRepository
{
    public Task<IEnumerable<TaskItem>> GetByTitleAsync(string title)
    {
        Expression<Func<TaskItem, bool>> taskTitleLikePredicate = task => task.Title.Contains(title);
        return FindAsync(taskTitleLikePredicate);
    }

    public Task<IEnumerable<TaskItem>> GetByStatusAsync(ETaskStatus status)
    {
        Expression<Func<TaskItem, bool>> taskStatusPredicate = task => task.Status == status;
        return FindAsync(taskStatusPredicate);
    }
}