using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

internal class TrafficEventRepository(TrafficContext _context, ILogger<IUnitOfWork> _logger) : ITrafficEventRepository
{
    public async Task<bool> Create(TrafficEvent trafficEvent, CancellationToken cancellationToken)
    {
        try
        {
            await _context.TrafficEvents.AddAsync(trafficEvent, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            int count = await _context.TrafficEvents
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return count > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<TrafficEvent> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.TrafficEvents
                .Where(x => x.Id == id)
                .Include(x => x.Traffic)
                .FirstOrDefaultAsync()
                ?? throw new NotFoundException("Traffic Event was not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<TrafficEvent>> List(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.TrafficEvents
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Traffic)
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(TrafficEvent trafficEvent, CancellationToken cancellationToken)
    {
        try
        {
            int count = await _context.TrafficEvents
                .Where(x => x.Id == trafficEvent.Id)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(p => p.Time, trafficEvent.Time)
                    .SetProperty(p => p.Number, trafficEvent.Number)
                    .SetProperty(p => p.Category, trafficEvent.Category)
                    .SetProperty(p => p.LaneId, trafficEvent.LaneId)
                    .SetProperty(p => p.Other, trafficEvent.Other)
                    .SetProperty(p => p.Value, trafficEvent.Value)
                    .SetProperty(p => p.Direction, trafficEvent.Direction), cancellationToken);

            return count > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }
}