using Domain.Entities;

namespace Domain.Repositories;

public interface ITrafficEventRepository
{
    Task<bool> Create(TrafficEvent trafficEvent, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);
    Task<bool> Update(TrafficEvent trafficEvent, CancellationToken cancellationToken);
    Task<TrafficEvent> GetById(int id, CancellationToken cancellationToken);
    Task<IEnumerable<TrafficEvent>> List(CancellationToken cancellationToken);
}