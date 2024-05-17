using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Traffics.Queries.GetTrafficById;

internal sealed class GetTrafficByIdHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetTrafficByIdQuery, GetTrafficByIdResponse>
{
    public async Task<GetTrafficByIdResponse> Handle(GetTrafficByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.TrafficRepository.GetById(request.SessionId, cancellationToken);
        return _mapper.Map<GetTrafficByIdResponse>(response);
    }
}