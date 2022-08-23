namespace Betting.Application.Betting;

public class BetListItemDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid FixtureId { get; set; }
    public decimal Amount { get; set; }
    public string Sport { get; set; }
    public string Competition { get; set; }
    public string Fixture { get; set; }
    public BetMarketDto Market { get; set; }
}