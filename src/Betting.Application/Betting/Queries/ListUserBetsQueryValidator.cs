using FluentValidation;

namespace Betting.Application.Betting.Queries;

public class ListUserBetsQueryValidator : AbstractValidator<ListUserBetsQuery>
{
    public ListUserBetsQueryValidator()
    {
        RuleFor(v => v.PageNumber)
            .GreaterThan(0).WithMessage("must be greater than 0")
            .LessThan(1000).WithMessage("must be less than 1000");

        RuleFor(v => v.ItemCount)
            .GreaterThan(0).WithMessage("must be greater than 0")
            .LessThan(100).WithMessage("must be less than 100");

        RuleFor(v => v.UserId)
            .NotNull()
            .NotEmpty().WithMessage("is required.");
    }
}

