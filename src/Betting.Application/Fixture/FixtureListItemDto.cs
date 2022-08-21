using Betting.Domain.Enums;

namespace Betting.Application.Fixture;

public class FixtureListItemDto
{
    public Guid FixtureId { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public FixtureStatus FixtureStatus { get; set; }
    public string FixtureStatusDescription { get; set; }

    public DateTime ClosingDate { get; set; }

    public List<FixtureTeamListItemDto> Teams { get; set; } = new List<FixtureTeamListItemDto>();
    public List<BaseFixtureMarketListItemDto> Markets { get; set; } = new List<BaseFixtureMarketListItemDto>();
}