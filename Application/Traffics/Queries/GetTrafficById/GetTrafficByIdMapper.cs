using Domain.Entities;
using Mapster;

namespace Application.Traffics.Queries.GetTrafficById;

public static class GetTrafficByIdMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<Traffic, GetTrafficByIdResponse>.NewConfig();
    }
}