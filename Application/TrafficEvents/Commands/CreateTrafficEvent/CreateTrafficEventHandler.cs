using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.TrafficEvents.Commands.CreateTrafficEvent;

internal sealed class CreateTrafficEventHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateTrafficEventCommand, CreateTrafficEventResponse>
{
    public async Task<CreateTrafficEventResponse> Handle(CreateTrafficEventCommand request, CancellationToken cancellationToken)
    {
        var trafficEvent = _mapper.Map<TrafficEvent>(request);

        await _unitOfWork.TrafficEventRepository.Create(trafficEvent, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return _mapper.Map<CreateTrafficEventResponse>(trafficEvent);
    }
}