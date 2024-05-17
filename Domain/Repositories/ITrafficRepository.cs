using Domain.Entities;

namespace Domain.Repositories;

public interface ITrafficRepository
{
    Task<bool> Create(Traffic traffic, CancellationToken cancellationToken);
    Task<bool> Delete(string sessionId, CancellationToken cancellationToken);
    Task<bool> Update(Traffic traffic, CancellationToken cancellationToken);
    Task<Traffic> GetById(string sessionId, CancellationToken cancellationToken);
    Task<IEnumerable<Traffic>> List(CancellationToken cancellationToken);
    Task<bool> IsExist(string sessionId, CancellationToken cancellationToken);
}