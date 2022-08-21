using System.ComponentModel.DataAnnotations.Schema;

namespace Betting.Domain.Models;

[NotMapped]
public class FixtureMarketAggregate
{
    public Guid FixtureId { get; set; }

    public List<FixtureMarket> Markets { get; set; }
}
