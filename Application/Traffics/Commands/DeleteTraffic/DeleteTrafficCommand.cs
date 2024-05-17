using MediatR;

namespace Application.Traffics.Commands.DeleteTraffic;

public sealed record DeleteTrafficCommand(string SessionId) : IRequest<bool>;