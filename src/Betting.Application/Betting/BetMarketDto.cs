using Betting.Domain.Enums;

namespace Betting.Application.Betting;

public class BetMarketDto
{
    public Guid Id { get; set; }
    public MarketType MarketType { get; set; }
    public string MarketTypeName { get; set; }
    public MarketSelectionDto Selection { get; set; }
}
