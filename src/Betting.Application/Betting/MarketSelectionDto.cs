using Betting.Domain.Enums;

namespace Betting.Application.Betting;

public class MarketSelectionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Settlement Settlement { get; set; }
    public double Odds { get; set; }
    public string SettlementName { get; internal set; }
}