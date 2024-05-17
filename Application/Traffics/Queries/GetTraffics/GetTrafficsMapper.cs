using Domain.Entities;
using Mapster;

namespace Application.Traffics.Queries.GetTraffics;

public static class GetTrafficsMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<Traffic, GetTrafficsResponse>.NewConfig();
    }
}