using Domain.Entities;
using MediatR;

namespace Application.Traffics.Commands.UpdateTraffic;

public sealed record UpdateTrafficCommand(
    string SystemName,
    string Vendor,
    string Subsystem,
    string Location0,
    string Location1,
    string Location2,
    int LaneCount,
    DateTime Begin,
    DateTime End,
    string SessionID,
    int CaseCount,
    List<TrafficEvent> TrafficEvents) : IRequest<UpdateTrafficResponse>;
