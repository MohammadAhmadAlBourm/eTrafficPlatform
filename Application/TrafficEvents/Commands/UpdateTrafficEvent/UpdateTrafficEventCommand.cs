using MediatR;

namespace Application.TrafficEvents.Commands.UpdateTrafficEvent;

public sealed record UpdateTrafficEventCommand(
    string SessionID,
    DateTime Time,
    int Number,
    string Category,
    int LaneId,
    string Other,
    int Value,
    int Direction) : IRequest<UpdateTrafficEventResponse>;