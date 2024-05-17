using Domain.Repositories;
using MediatR;

namespace Application.TrafficEvents.Commands.DeleteTrafficEvent;

internal sealed class DeleteTrafficEventHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteTrafficEventCommand, bool>
{
    public async Task<bool> Handle(DeleteTrafficEventCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.TrafficEventRepository.Delete(request.Id, cancellationToken);
    }
}
