using FluentValidation;

namespace Application.TrafficEvents.Commands.UpdateTrafficEvent;

internal sealed class UpdateTrafficEventValidator : AbstractValidator<UpdateTrafficEventCommand>
{
    public UpdateTrafficEventValidator()
    {

    }
}