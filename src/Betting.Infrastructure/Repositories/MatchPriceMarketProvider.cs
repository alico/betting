using Betting.Domain.Contracts;
using Betting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Betting.Infrastructure.Repositories;
public class MatchPriceMarketProvider : IProvideMatchPriceMarket
{
    private readonly IQueryDBContext _dbContext;
    public MatchPriceMarketProvider(IQueryDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<MatchPriceMarket>> Get(List<Guid> fixtureMarketIds, CancellationToken cancellationToken)
    {
        //TODO: Get only what you need rather than everything.
        return await _dbContext.MatchPriceMarket
                                .Include(x => x.FixtureMarket)
                                .ThenInclude(x => x.MarketType)
                                .Include(x => x.MatchPriceSelections)
                                .ThenInclude(x => x.MatchPriceSelectionType)
                                .Include(x => x.MatchPriceSelections)
                                .ThenInclude(x => x.Settlement)
                                .Where(x => fixtureMarketIds.Contains(x.FixtureMarketId))
                                .ToListAsync(cancellationToken);
    }

    public async Task<MatchPriceMarket> Get(Guid matchPriceMarketId, CancellationToken cancellationToken)
    {
        //TODO: Get only what you need rather than everything.
        return await _dbContext.MatchPriceMarket
                                .Include(x => x.FixtureMarket)
                                .ThenInclude(x => x.MarketType)
                                .Include(x=>x.FixtureMarket.Fixture)
                                .Include(x => x.MatchPriceSelections)
                                .ThenInclude(x => x.MatchPriceSelectionType)
                                .Where(x => x.Id == matchPriceMarketId)
                                .FirstAsync(cancellationToken);
    }
}