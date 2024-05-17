using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

internal class TrafficRepository(TrafficContext _context, ILogger<IUnitOfWork> _logger) : ITrafficRepository
{
    public async Task<bool> Create(Traffic traffic, CancellationToken cancellationToken)
    {
        try
        {
            await _context.Traffics.AddAsync(traffic, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> Delete(string sessionId, CancellationToken cancellationToken)
    {
        try
        {
            int count = await _context.Traffics
                .Where(x => x.SessionID == sessionId)
                .ExecuteDeleteAsync(cancellationToken);

            return count > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<Traffic> GetById(string sessionId, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Traffics
                .Where(x => x.SessionID == sessionId)
                .Include(x => x.TrafficEvents)
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundException("Traffic was not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> IsExist(string sessionId, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Traffics.AnyAsync(x => x.SessionID == sessionId, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Traffic>> List(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Traffics
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.TrafficEvents)
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(Traffic traffic, CancellationToken cancellationToken)
    {
        try
        {
            int count = await _context.Traffics
                .Where(x => x.SessionID == traffic.SessionID)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(p => p.SystemName, traffic.SystemName)
                    .SetProperty(p => p.Vendor, traffic.Vendor)
                    .SetProperty(p => p.Subsystem, traffic.Subsystem)
                    .SetProperty(p => p.Location0, traffic.Location0)
                    .SetProperty(p => p.Location1, traffic.Location1)
                    .SetProperty(p => p.Location2, traffic.Location2)
                    .SetProperty(p => p.LaneCount, traffic.LaneCount)
                    .SetProperty(p => p.Begin, traffic.Begin)
                    .SetProperty(p => p.End, traffic.End)
                    .SetProperty(p => p.CaseCount, traffic.CaseCount)

                    , cancellationToken);

            return count > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception Occurred {Message}", ex.Message);
            throw;
        }
    }
}
