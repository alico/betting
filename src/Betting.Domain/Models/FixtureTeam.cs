namespace Betting.Domain.Models;
public class FixtureTeam : BaseEntity<Guid>
{
    public Guid FixtureId { get; set; }

    public Guid TeamId { get; set; }

    public Fixture Fixture { get; set; }

    public Team Team { get; set; }
}
