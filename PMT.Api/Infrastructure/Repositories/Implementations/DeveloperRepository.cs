using System.Linq.Expressions;
using PMT.Api.Infrastructure.Data.Context;
using PMT.Api.Infrastructure.Repositories.Base;
using PMT.Core.Contracts.Repositories;
using PMT.Core.Models;

namespace PMT.Api.Infrastructure.Repositories.Implementations;

public class DeveloperRepository(AppDbContext context) : BaseRepository<Developer>(context), IDeveloperRepository
{
    public Task<IEnumerable<Developer>> GetAllActiveAsync()
    {
        Expression<Func<Developer, bool>> activeDeveloperPredicate = developer => developer.IsActive;
        return FindAsync(activeDeveloperPredicate);
    }

    public Task<IEnumerable<Developer>> GetByNameAsync(string name)
    {
        Expression<Func<Developer, bool>> developerNameLikePredicate = developer => developer.Name.Contains(name);
        return FindAsync(developerNameLikePredicate);
    }
}