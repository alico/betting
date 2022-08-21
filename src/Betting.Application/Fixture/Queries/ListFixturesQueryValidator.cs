using FluentValidation;

namespace Betting.Application.Fixture.Queries;

public class ListFixturesQueryValidator : AbstractValidator<ListFixturesQuery>
{
    public ListFixturesQueryValidator()
    {
        RuleFor(v => v.PageNumber)
            .GreaterThan(0).WithMessage("must be greater than 0")
            .LessThan(1000).WithMessage("must be less than 1000");

        RuleFor(v => v.ItemCount)
            .GreaterThan(0).WithMessage("must be greater than 0")
            .LessThan(100).WithMessage("must be less than 100");

        RuleFor(f => f).Must(x => AtLeastOneFilterSelected(x.SportId, x.CompetitionId, x.FixtureId)).WithMessage("You must use at least one filter.");
    }

    public bool AtLeastOneFilterSelected(Guid? sportId, Guid? competitionId, Guid? fixtureId)
    {
        return sportId.HasValue || competitionId.HasValue || fixtureId.HasValue;
    }
}

