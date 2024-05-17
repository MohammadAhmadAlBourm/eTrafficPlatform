using Domain.Entities;
using Mapster;

namespace Application.TrafficEvents.Commands.UpdateTrafficEvent;

public static class UpdateTrafficEventMapper
{
    public static void Configure()
    {

        TypeAdapterConfig<UpdateTrafficEventCommand, TrafficEvent>.NewConfig();
        TypeAdapterConfig<TrafficEvent, UpdateTrafficEventResponse>.NewConfig();

    }
}