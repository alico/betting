namespace Betting.Domain.Models;
public class MatchPriceSelectionType : BaseEntity<short>
{
    public short MatchPriceSelectionTypeId { get; set; }

    public string Name { get; set; }
}
