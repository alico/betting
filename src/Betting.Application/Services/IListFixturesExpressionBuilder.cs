using Betting.Application.Fixture.Queries;
using System.Linq.Expressions;

namespace Betting.Application.Services;

public interface IListFixturesExpressionBuilder
{
    IListFixturesExpressionBuilder Init(ListFixturesQuery query);

    IListFixturesExpressionBuilder AddSportId();

    IListFixturesExpressionBuilder AddCompetitionId();

    IListFixturesExpressionBuilder AddFixtureId();

    Expression<Func<Domain.Models.Fixture, bool>> Build();
}
