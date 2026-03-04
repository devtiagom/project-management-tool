using PMT.Core.Models;

namespace PMT.Core.Contracts.Repositories;

public interface IDeveloperRepository : IBaseRepository<Developer>
{
    Task<IEnumerable<Developer>> GetAllActiveAsync();
    Task<IEnumerable<Developer>> GetByNameAsync(string name);
}