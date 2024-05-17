using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.TrafficEvents.Commands.UpdateTrafficEvent;

internal sealed class UpdateTrafficEventHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdateTrafficEventCommand, UpdateTrafficEventResponse>
{
    public async Task<UpdateTrafficEventResponse> Handle(UpdateTrafficEventCommand request, CancellationToken cancellationToken)
    {
        var trafficEvent = _mapper.Map<TrafficEvent>(request);

        await _unitOfWork.TrafficEventRepository.Update(trafficEvent, cancellationToken);

        return _mapper.Map<UpdateTrafficEventResponse>(trafficEvent);
    }
}