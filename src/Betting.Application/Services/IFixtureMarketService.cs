using Betting.Application.Fixture;
using Betting.Domain.Models;

namespace Betting.Application.Services;

public interface IFixtureMarketService
{
    Task<Dictionary<Guid, List<BaseFixtureMarketListItemDto>>> GetFixtureMarkets(List<FixtureMarketAggregate> fixtureMarkets, CancellationToken cancellationToken);
}