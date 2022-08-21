using System.ComponentModel.DataAnnotations;

namespace Betting.Domain.Models;
public class Fixture : BaseEntity<Guid>
{
    public Guid CompetitionId { get; set; }

    [StringLength(200)]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Competition Competition { get; set; }
    public ICollection<FixtureMarket> FixtureMarkets { get; set; }
    public ICollection<FixtureTeam> Teams { get; set; }
}
