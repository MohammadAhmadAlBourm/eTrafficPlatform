using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Traffics.Commands.CreateTraffic;

internal sealed class CreateTrafficHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateTrafficCommand, CreateTrafficResponse>
{
    public async Task<CreateTrafficResponse> Handle(CreateTrafficCommand request, CancellationToken cancellationToken)
    {
        var traffic = _mapper.Map<Traffic>(request);

        await _unitOfWork.TrafficRepository.Create(traffic, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return _mapper.Map<CreateTrafficResponse>(traffic);
    }
}