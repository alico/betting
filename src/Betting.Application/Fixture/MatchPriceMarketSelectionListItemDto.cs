namespace Betting.Application.Fixture;

public class MatchPriceMarketSelectionListItemDto
{
    public Guid Id { get; set; }
    public Domain.Enums.MatchPriceSelectionType SelectionType { get; set; }
    public string SelectionTypeName { get; set; }
    public Domain.Enums.Settlement Settlement{ get; set; }
    public string SettlementName { get; set; }
    public double Odds { get; set; }
}
