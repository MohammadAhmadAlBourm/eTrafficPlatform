using MediatR;

namespace Application.TrafficEvents.Commands.CreateTrafficEvent;

public sealed record CreateTrafficEventCommand(
    string SessionID,
    DateTime Time,
    int Number,
    string Category,
    int LaneId,
    string Other,
    int Value,
    int Direction) : IRequest<CreateTrafficEventResponse>;