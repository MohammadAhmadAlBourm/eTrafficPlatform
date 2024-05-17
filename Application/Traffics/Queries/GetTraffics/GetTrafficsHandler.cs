using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Traffics.Queries.GetTraffics;

internal class GetTrafficsHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetTrafficsQuery, IEnumerable<GetTrafficsResponse>>
{
    public async Task<IEnumerable<GetTrafficsResponse>> Handle(GetTrafficsQuery request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.TrafficRepository.List(cancellationToken);
        return _mapper.Map<IEnumerable<GetTrafficsResponse>>(response);
    }
}