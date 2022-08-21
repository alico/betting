namespace Betting.Domain.Models;
public class MatchPriceMarket : BaseEntity<Guid>
{
    public Guid FixtureMarketId { get; set; }

    public Guid HomeTeamId { get; set; }

    public Guid AwayTeamId { get; set; }

    public FixtureMarket FixtureMarket { get; set; }

    public ICollection<MatchPriceSelection> MatchPriceSelections { get; set; }
}
