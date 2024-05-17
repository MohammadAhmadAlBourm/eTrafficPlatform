using MediatR;

namespace Application.Traffics.Queries.GetTrafficById;

public sealed record GetTrafficByIdQuery(string SessionId) : IRequest<GetTrafficByIdResponse>;