using System.ComponentModel.DataAnnotations;

namespace Betting.Domain.Models;
public class Team : BaseEntity<Guid>
{
    [StringLength(200)]
    public string Name { get; set; }
}
