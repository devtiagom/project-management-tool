using PMT.Core.Contracts.Repositories;

namespace PMT.Core.Contracts;

public interface IUnitOfWork : IDisposable
{
    IDeveloperRepository Developers { get; }
    IProjectRepository Projects { get; }
    ITaskItemRepository Tasks { get; }
    
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task<int> CompleteAsync();
}