using Domain.Entities;
using Mapster;

namespace Application.Traffics.Commands.UpdateTraffic;

public static class UpdateTrafficMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<UpdateTrafficCommand, Traffic>.NewConfig();
        TypeAdapterConfig<Traffic, UpdateTrafficResponse>.NewConfig();
    }
}