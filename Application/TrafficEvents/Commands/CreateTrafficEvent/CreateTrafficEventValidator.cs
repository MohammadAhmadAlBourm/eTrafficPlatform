using FluentValidation;

namespace Application.TrafficEvents.Commands.CreateTrafficEvent;

internal sealed class CreateTrafficEventValidator : AbstractValidator<CreateTrafficEventCommand>
{
    public CreateTrafficEventValidator()
    {

    }
}