using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

internal class UnitOfWork : IUnitOfWork, IDisposable
{
    public ITrafficEventRepository TrafficEventRepository { get; private set; }

    public ITrafficRepository TrafficRepository { get; private set; }

    private readonly TrafficContext _context;
    private readonly ILogger<IUnitOfWork> _logger;

    public UnitOfWork(TrafficContext context, ILogger<IUnitOfWork> logger)
    {
        _context = context;
        _logger = logger;

        TrafficEventRepository = new TrafficEventRepository(_context, _logger);
        TrafficRepository = new TrafficRepository(_context, _logger);
    }

    public async Task CompleteAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}