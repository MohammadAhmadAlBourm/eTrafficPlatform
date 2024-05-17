using Application.TrafficEvents.Commands.CreateTrafficEvent;
using Domain.Entities;
using Mapster;

namespace Application.Traffics.Commands.CreateTraffic;

public static class CreateTrafficMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<CreateTrafficCommand, Traffic>.NewConfig();
        TypeAdapterConfig<Traffic, CreateTrafficEventResponse>.NewConfig();
    }
}