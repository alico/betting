using System.ComponentModel.DataAnnotations;

namespace Betting.Domain.Models;
public class Competition : BaseEntity<Guid>
{
    public Guid SportId { get; set; }

    [StringLength(200)]
    public string Name { get; set; }

    public Sport Sport { get; set; }

    public ICollection<Fixture> Fixtures { get; set; }

}
