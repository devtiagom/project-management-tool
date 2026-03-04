using PMT.Core.Enums;
using PMT.Core.Models;

namespace PMT.Core.Contracts.Repositories;

public interface IProjectRepository : IBaseRepository<Project>
{
    Task<IEnumerable<Project>> GetByTitleAsync(string title);
    Task<IEnumerable<Project>> GetByStatusAsync(EProjectStatus status);
}