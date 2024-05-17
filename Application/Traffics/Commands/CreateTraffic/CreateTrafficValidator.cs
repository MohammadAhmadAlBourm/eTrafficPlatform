using FluentValidation;

namespace Application.Traffics.Commands.CreateTraffic;

internal sealed class CreateTrafficValidator : AbstractValidator<CreateTrafficCommand>
{
    public CreateTrafficValidator()
    {

    }
}