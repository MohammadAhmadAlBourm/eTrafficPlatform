using Domain.Entities;
using Mapster;

namespace Application.TrafficEvents.Queries.GetTrafficEventById;

public static class GetTrafficEventByIdMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<TrafficEvent, GetTrafficEventByIdResponse>.NewConfig();
    }
}