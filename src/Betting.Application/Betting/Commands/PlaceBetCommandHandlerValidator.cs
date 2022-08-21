using FluentValidation;

namespace Betting.Application.Betting.Commands;

public class PlaceBetCommandHandlerValidator : AbstractValidator<PlaceBetCommand>
{
    public PlaceBetCommandHandlerValidator()
    {
        RuleFor(v => v.UserId)
          .NotNull()
          .NotEmpty().WithMessage("is required.");

        RuleFor(v => v.FixtureId)
          .NotNull()
          .NotEmpty().WithMessage("is required.");

        RuleFor(v => v.MarketId)
          .NotNull()
          .NotEmpty().WithMessage("is required.");

        RuleFor(v => v.SelectionId)
          .NotNull()
          .NotEmpty().WithMessage("is required.");

        RuleFor(v => v.MarketType)
          .IsInEnum().WithMessage("is not valid");

        RuleFor(v => v.Amount)
          .GreaterThan(0).WithMessage("must be greater than 0.")
          .LessThan(decimal.MaxValue).WithMessage($"must be less than or equal to {decimal.MaxValue}.");
    }
}

