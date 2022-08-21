using System.ComponentModel.DataAnnotations;

namespace Betting.Domain.Models;
public class Sport : BaseEntity<Guid>
{
    [StringLength(200)]
    public string Name { get; set; }

    public ICollection<Competition> Competitions { get; set; }
}
