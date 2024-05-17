using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Traffics.Commands.UpdateTraffic;

internal sealed class UpdateTrafficHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdateTrafficCommand, UpdateTrafficResponse>
{
    public async Task<UpdateTrafficResponse> Handle(UpdateTrafficCommand request, CancellationToken cancellationToken)
    {
        var traffic = _mapper.Map<Traffic>(request);

        await _unitOfWork.TrafficRepository.Update(traffic, cancellationToken);
        return _mapper.Map<UpdateTrafficResponse>(traffic);
    }
}