using Domain.Entities;
using Mapster;

namespace Application.TrafficEvents.Queries.GetTrafficEvents;

public static class GetTrafficEventsMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<TrafficEvent, GetTrafficEventsResponse>.NewConfig();
    }
}