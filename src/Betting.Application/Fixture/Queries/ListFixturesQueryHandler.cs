using Betting.Application.Services;
using Betting.Domain.Contracts;
using Betting.Domain.Models;
using MediatR;

namespace Betting.Application.Fixture.Queries;
public class ListFixturesQueryHandler : IRequestHandler<ListFixturesQuery, IEnumerable<FixtureListItemDto>>
{
    private readonly IListFixturesExpressionBuilder _queryBuilder;
    private readonly IProvideFixture _fixtureProvider;
    private readonly IFixtureMarketService _fixtureMarketService;

    public ListFixturesQueryHandler(IListFixturesExpressionBuilder queryBuilder, IFixtureMarketService fixtureMarketService, IProvideFixture fixtureProvider)
    {
        _fixtureMarketService = fixtureMarketService;
        _queryBuilder = queryBuilder;
        _fixtureProvider = fixtureProvider;
    }
    public async Task<IEnumerable<FixtureListItemDto>> Handle(ListFixturesQuery request, CancellationToken cancellationToken)
    {
        //Build an expression based on the request model
        var expression = _queryBuilder.Init(request).AddSportId().AddCompetitionId().AddFixtureId().Build();

        //Get fixtures
        var fixtures = await _fixtureProvider.GetFixtures(expression, request.PageNumber, request.ItemCount, cancellationToken);

        //Get Fixture Markets to be queried from the database
        var markets = fixtures.Select(y => new FixtureMarketAggregate
        {
            FixtureId = y.Id,
            Markets = y.FixtureMarkets.ToList(),
        }).ToList();

        //Get Markets with selections
        var marketsWithSelections = await _fixtureMarketService.GetFixtureMarkets(markets, cancellationToken);

        //TODO: Add AutoMapper
        return fixtures.Select(x => new FixtureListItemDto()
        {
            FixtureId = x.Id,
            Name = x.Name,
            ClosingDate = x.ClosingDate,
            Date = x.Date,
            FixtureStatus = (Domain.Enums.FixtureStatus)x.FixtureStatusId,
            FixtureStatusDescription = x.FixtureStatus.Name,
            Markets = marketsWithSelections.Where(m => m.Key == x.Id).Select(x => x.Value).First(),
            Teams = x.Teams.Select(y => new FixtureTeamListItemDto()
            {
                Id = y.Team.Id,
                Name = y.Team.Name
            }).ToList(),
        }).ToList();
    }
}