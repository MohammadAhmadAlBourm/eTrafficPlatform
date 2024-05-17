using FluentValidation;

namespace Application.TrafficEvents.Commands.CreateTrafficEvent;

internal sealed class CreateTrafficEventValidator : AbstractValidator<CreateTrafficEventCommand>
{
    public CreateTrafficEventValidator()
    {
        RuleFor(x => x.SessionID)
                .NotEmpty().WithMessage("SessionID is required.")
                .Length(1, 50).WithMessage("SessionID must be between 1 and 50 characters.");

        RuleFor(x => x.Time)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Time cannot be in the future.");

        RuleFor(x => x.Number)
            .GreaterThanOrEqualTo(0).WithMessage("Number must be zero or greater.");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required.")
            .MaximumLength(100).WithMessage("Category cannot be longer than 100 characters.");

        RuleFor(x => x.LaneId)
            .GreaterThan(0).WithMessage("LaneId must be greater than zero.");

        RuleFor(x => x.Other)
            .MaximumLength(200).WithMessage("Other cannot be longer than 200 characters.");

        RuleFor(x => x.Value)
            .GreaterThanOrEqualTo(0).WithMessage("Value must be zero or greater.");

        RuleFor(x => x.Direction)
            .InclusiveBetween(0, 360).WithMessage("Direction must be between 0 and 360 degrees.");

    }
}