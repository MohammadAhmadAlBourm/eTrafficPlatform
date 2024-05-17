using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.TrafficEvents.Queries.GetTrafficEvents;

internal sealed class GetTrafficEventsHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetTrafficEventsQuery, IEnumerable<GetTrafficEventsResponse>>
{
    public async Task<IEnumerable<GetTrafficEventsResponse>> Handle(GetTrafficEventsQuery request, CancellationToken cancellationToken)
    {
        var trafficEvents = await _unitOfWork.TrafficEventRepository.List(cancellationToken);
        return _mapper.Map<IEnumerable<GetTrafficEventsResponse>>(trafficEvents);
    }
}
