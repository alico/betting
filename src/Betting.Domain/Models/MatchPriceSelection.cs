namespace Betting.Domain.Models;
public class MatchPriceSelection : BaseEntity<Guid>
{
    public Guid MatchPriceMarketId { get; set; }

    public short MatchPriceSelectionTypeId { get; set; }

    public double Odds { get; set; }

    public short SettlementId { get; set; }

    public Settlement Settlement { get; set; }

    public MatchPriceMarket Market { get; set; }

    public MatchPriceSelectionType MatchPriceSelectionType { get; set; }
}
