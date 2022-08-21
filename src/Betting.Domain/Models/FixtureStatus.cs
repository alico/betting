using System.ComponentModel.DataAnnotations;

namespace Betting.Domain.Models;
public class FixtureStatus: BaseEntity<short>
{
    [StringLength(200)]
    public string Name { get; set; }
}
