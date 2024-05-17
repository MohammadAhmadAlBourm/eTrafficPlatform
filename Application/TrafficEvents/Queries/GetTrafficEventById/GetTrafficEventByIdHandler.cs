using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.TrafficEvents.Queries.GetTrafficEventById;

internal sealed class GetTrafficEventByIdHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetTrafficEventByIdQuery, GetTrafficEventByIdResponse>
{
    public async Task<GetTrafficEventByIdResponse> Handle(GetTrafficEventByIdQuery request, CancellationToken cancellationToken)
    {
        var trafficEvent = await _unitOfWork.TrafficEventRepository.GetById(request.Id, cancellationToken);
        return _mapper.Map<GetTrafficEventByIdResponse>(trafficEvent);
    }
}