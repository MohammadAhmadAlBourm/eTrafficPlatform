using Domain.Repositories;
using MediatR;

namespace Application.Traffics.Commands.DeleteTraffic;

internal sealed class DeleteTrafficHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteTrafficCommand, bool>
{
    public async Task<bool> Handle(DeleteTrafficCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.TrafficRepository.Delete(request.SessionId, cancellationToken);
    }
}
