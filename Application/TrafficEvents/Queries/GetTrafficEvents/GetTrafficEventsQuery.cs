using MediatR;

namespace Application.TrafficEvents.Queries.GetTrafficEvents;

public sealed record GetTrafficEventsQuery() : IRequest<IEnumerable<GetTrafficEventsResponse>>;