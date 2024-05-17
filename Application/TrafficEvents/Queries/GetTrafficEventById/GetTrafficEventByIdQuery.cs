using MediatR;

namespace Application.TrafficEvents.Queries.GetTrafficEventById;

public sealed record GetTrafficEventByIdQuery(int Id) : IRequest<GetTrafficEventByIdResponse>;