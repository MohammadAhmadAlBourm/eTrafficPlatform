using MediatR;

namespace Application.TrafficEvents.Commands.DeleteTrafficEvent;

public sealed record DeleteTrafficEventCommand(int Id) : IRequest<bool>;