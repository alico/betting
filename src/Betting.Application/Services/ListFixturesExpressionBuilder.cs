using Betting.Application.Fixture.Queries;
using System.Linq.Expressions;

namespace Betting.Application.Services;
public class ListFixturesExpressionBuilder : IListFixturesExpressionBuilder
{
    private Expression<Func<Domain.Models.Fixture, bool>> _expression;
    private ListFixturesQuery _query;

    public IListFixturesExpressionBuilder AddSportId()
    {
        if (_query.SportId.HasValue)
            _expression = _expression.And(x => x.Competition.SportId == _query.SportId);

        return this;
    }

    public IListFixturesExpressionBuilder AddCompetitionId()
    {
        if (_query.CompetitionId.HasValue)
            _expression = _expression.And(x => x.CompetitionId == _query.CompetitionId);

        return this;
    }

    public IListFixturesExpressionBuilder AddFixtureId()
    {
        if (_query.FixtureId.HasValue)
            _expression = _expression.And(x => x.Id == _query.FixtureId);

        return this;
    }

    public IListFixturesExpressionBuilder Init(ListFixturesQuery query)
    {
        _expression = ExpressionBuilder.True<Domain.Models.Fixture>();
        _query = query;

        return this;
    }

    Expression<Func<Domain.Models.Fixture, bool>> IListFixturesExpressionBuilder.Build()
    {
        return _expression;
    }
}
