using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PMT.Api.Infrastructure.Data.Context;
using PMT.Core.Contracts.Repositories;

namespace PMT.Api.Infrastructure.Repositories.Base;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<T> DbSet;

    public BaseRepository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }
    
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<T?> FindSingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.SingleOrDefaultAsync(predicate);
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public virtual void Update(T entity)
    {
        var entry = Context.Entry(entity);
        if (entry.State != EntityState.Detached) return;
        DbSet.Attach(entity);
        entry.State = EntityState.Modified;
    }

    public virtual void Remove(T entity)
    {
        if (Context.Entry(entity).State == EntityState.Detached)
            DbSet.Attach(entity);
        DbSet.Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        DbSet.RemoveRange(entities);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.AnyAsync(predicate);
    }

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate is null 
            ? await DbSet.CountAsync()
            : await DbSet.CountAsync(predicate);
    }
}