namespace Betting.Application.Fixture;

public class MatchPriceMarketSelectionListItemDto
{
    public Guid Id { get; set; }
    public Domain.Enums.MatchPriceSelectionType SelectionType { get; set; }
    public string SelectionTypeName { get; set; }
    public double Value { get; set; }
}
