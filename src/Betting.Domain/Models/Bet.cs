namespace Betting.Domain.Models;
public class Bet : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid FixtureId { get; set; }
    public Guid MarketId { get; set; }
    public Guid SelectionId { get; set; }
    public short MarketTypeId { get; set; }
    public decimal Amount { get; set; }
    public short BetSettlementId { get; set; }

    public BetSettlement BetSettlement { get; set; }
    public User User { get; set; }
    public Fixture Fixture { get; set; }
}
