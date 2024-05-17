using Domain.Entities;
using Mapster;

namespace Application.TrafficEvents.Commands.CreateTrafficEvent;

public static class CreateTrafficEventMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<CreateTrafficEventCommand, TrafficEvent>.NewConfig();
        TypeAdapterConfig<TrafficEvent, CreateTrafficEventResponse>.NewConfig();

    }
}