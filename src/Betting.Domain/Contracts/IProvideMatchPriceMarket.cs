using Betting.Domain.Models;

namespace Betting.Domain.Contracts;
public interface IProvideMatchPriceMarket
{
    Task<List<MatchPriceMarket>> Get(List<Guid> fixtureMarketIds, CancellationToken cancellationToken);
    Task<MatchPriceMarket> Get(Guid matchPriceMarketId, CancellationToken cancellationToken);
}