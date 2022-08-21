namespace Betting.Application.Fixture;

public abstract class BaseFixtureMarketListItemDto
{
    public Guid Id { get; set; }
    public Guid FixtureId { get; set; }
    public Domain.Enums.MarketType MarketType { get; set; }
    public string MarketTypeName { get; set; }
}
