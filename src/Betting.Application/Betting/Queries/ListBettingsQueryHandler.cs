using Betting.Application.Fixture;
using Betting.Application.Services;
using Betting.Domain.Contracts;
using Betting.Domain.Models;
using MediatR;

namespace Betting.Application.Betting.Queries;
public class ListBettingsQueryHandler : IRequestHandler<ListUserBetsQuery, IEnumerable<BetListItemDto>>
{
    private readonly IProvideUserBetting _provideUserBetting;
    private readonly IFixtureMarketService _fixtureMarketService;

    public ListBettingsQueryHandler(IFixtureMarketService fixtureMarketService, IProvideUserBetting provideUserBetting)
    {
        _fixtureMarketService = fixtureMarketService;
        _provideUserBetting = provideUserBetting;
    }
    public async Task<IEnumerable<BetListItemDto>> Handle(ListUserBetsQuery request, CancellationToken cancellationToken)
    {
        var result = new List<BetListItemDto>();

        //Get user's bettings
        var bets = await _provideUserBetting.Get(request.UserId, request.PageNumber, request.ItemCount, cancellationToken);

        if (bets.Count == 0)
            return result;

        //Get Fixture Markets to be queried from the database
        var fixtureMarketAggregate = bets.Select(y => new FixtureMarketAggregate
        {
            FixtureId = y.Id,
            Markets = y.Fixture.FixtureMarkets.ToList(),
        }).ToList();

        //TODO: Use distributed cache to get Markets & Selection
        var markets = await _fixtureMarketService.GetFixtureMarkets(fixtureMarketAggregate, cancellationToken);

        //TODO: Move this logic to a service
        //TODO: Adding a factory pattern would be great here to create other markets providers when we have multiple markets in the future.
        foreach (var bet in bets)
        {
            var market = markets
                        .Where(x => x.Key == bet.FixtureId)
                        .Select(x => x.Value.FirstOrDefault(y => y.Id == bet.MarketId && y.MarketType == (Domain.Enums.MarketType)bet.MarketTypeId))
                        .FirstOrDefault();


            if (market?.MarketType == Domain.Enums.MarketType.MatchPriceMarket)
            {
                var selection = ((MatchPriceMarketDto)market).Selections.Where(x => x.Id == bet.SelectionId).FirstOrDefault();

                //TODO: Builder pattern and AutoMapper would be useful here to construct the object.
                var item = new BetListItemDto()
                {
                    Id = bet.Id,
                    Amount = bet.Amount,
                    FixtureId = bet.FixtureId,
                    UserId = bet.UserId,
                    Sport = bet.Fixture.Competition.Sport.Name,
                    Competition = bet.Fixture.Competition.Name,
                    Fixture = bet.Fixture.Name,
                    Market = new BetMarketDto()
                    {
                        Id = market.Id,
                        MarketType = market.MarketType,
                        MarketTypeName = market.MarketTypeName,
                        Selection = new MarketSelectionDto()
                        {
                            Id = bet.SelectionId,
                            Odds = selection.Odds,
                            Name = selection.SelectionTypeName,
                            Settlement = selection.Settlement,
                            SettlementName = selection.SettlementName
                        }
                    }

                };
                result.Add(item);
            }
        }

        return result;
    }
}