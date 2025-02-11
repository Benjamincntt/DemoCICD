namespace DemoCICD.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    ///     Call save change from dbcontext
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CommitAsync(CancellationToken cancellationToken = default);
}