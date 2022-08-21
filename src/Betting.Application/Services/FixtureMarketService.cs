using AutoMapper;
using AutoMapper.QueryableExtensions;
using Betting.Application.Fixture;
using Betting.Domain.Contracts;
using Betting.Domain.Models;

namespace Betting.Application.Services;
public class FixtureMarketService : IFixtureMarketService
{
    private readonly IProvideMatchPriceMarket _matchPriceMarketProvider;
    private readonly IMapper _mapper;
    public FixtureMarketService(IProvideMatchPriceMarket matchPriceMarketProvider, IMapper mapper)
    {
        _matchPriceMarketProvider = matchPriceMarketProvider;
        _mapper = mapper;
    }
    public async Task<Dictionary<Guid, List<BaseFixtureMarketListItemDto>>> GetFixtureMarkets(List<FixtureMarketAggregate> fixtureMarkets, CancellationToken cancellationToken)
    {
        var result = new List<BaseFixtureMarketListItemDto>();

        //TODO: Adding a factory pattern would be great here to create other markets providers when we have multiple markets in future.
        //For now, we have only one market "MatchPriceMarket", so let's collect the martketFixtureId of MatchPriceMarkets
        if (fixtureMarkets.Any(x => x.Markets.Any(y => y.MarketTypeId == (short)Domain.Enums.MarketType.MatchPriceMarket)))
        {
            var fixtureMarketIds = fixtureMarkets
                                    .SelectMany(x => x.Markets.Where(y => y.MarketTypeId == (short)Domain.Enums.MarketType.MatchPriceMarket))
                                    .Select(x => x.Id)
                                    .ToList();

            var fixtureMarketsWithSelections = await _matchPriceMarketProvider.Get(fixtureMarketIds, cancellationToken);
            var matchPriceMarkets = fixtureMarketsWithSelections.AsQueryable().ProjectTo<MatchPriceMarketDto>(_mapper.ConfigurationProvider);

            result.AddRange(matchPriceMarkets);
        }

        return result.GroupBy(o => o.FixtureId).ToDictionary(g => g.Key, g => g.ToList());
    }
}
