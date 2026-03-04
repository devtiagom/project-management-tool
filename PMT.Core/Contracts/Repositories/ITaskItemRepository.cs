using PMT.Core.Enums;
using PMT.Core.Models;

namespace PMT.Core.Contracts.Repositories;

public interface ITaskItemRepository : IBaseRepository<TaskItem>
{
    Task<IEnumerable<TaskItem>> GetByTitleAsync(string title);
    Task<IEnumerable<TaskItem>> GetByStatusAsync(ETaskStatus status);
}