namespace Betting.Domain.Models;
public class FixtureMarket : BaseEntity<Guid>
{
    public Guid FixtureId { get; set; }
    public short MarketTypeId { get; set; }

    public Fixture Fixture { get; set; }
    public MarketType MarketType { get; set; }
}
