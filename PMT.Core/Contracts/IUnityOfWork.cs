using PMT.Core.Contracts.Repositories;

namespace PMT.Core.Contracts;

public interface IUnityOfWork : IDisposable
{
    IDeveloperRepository DeveloperRepository { get; }
    IProjectRepository ProjectRepository { get; }
    ITaskItemRepository TaskItemRepository { get; }
    
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task<int> CompleteAsync();
}