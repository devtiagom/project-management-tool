using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PMT.Api.Infrastructure.Data.Context;
using PMT.Api.Infrastructure.Repositories.Implementations;
using PMT.Core.Contracts;
using PMT.Core.Contracts.Repositories;

namespace PMT.Api.Infrastructure.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    private bool _disposed = false;
    
    private IDeveloperRepository? _developerRepository;
    private IProjectRepository? _projectRepository;
    private ITaskItemRepository? _taskItemRepository;

    public IDeveloperRepository Developers => 
        _developerRepository ??= new DeveloperRepository(context);

    public IProjectRepository Projects => 
        _projectRepository ??= new ProjectRepository(context);

    public ITaskItemRepository Tasks => 
        _taskItemRepository ??= new TaskItemRepository(context);

    public async Task BeginTransactionAsync()
    {
        _transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            if (_transaction is not null) await _transaction.CommitAsync();
        }
        finally
        {
            if (_transaction is not null) await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        try
        {
            if (_transaction is not null) await _transaction.RollbackAsync();
        }
        finally
        {
            if (_transaction is not null) await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task<int> CompleteAsync()
    {
        try
        {
            return await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Erro ao persistir dados. Verifique os dados e tente novamente.", ex);
        }
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _transaction?.Dispose();
            context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}