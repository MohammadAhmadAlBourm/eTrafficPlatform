using MediatR;

namespace Application.Traffics.Queries.GetTraffics;

public sealed record GetTrafficsQuery() : IRequest<IEnumerable<GetTrafficsResponse>>;