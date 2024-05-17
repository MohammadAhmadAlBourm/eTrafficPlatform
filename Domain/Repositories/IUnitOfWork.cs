namespace Domain.Repositories;

public interface IUnitOfWork
{
    ITrafficEventRepository TrafficEventRepository { get; }
    ITrafficRepository TrafficRepository { get; }

    Task CompleteAsync(CancellationToken cancellationToken);
}
