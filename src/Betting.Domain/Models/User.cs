using System.ComponentModel.DataAnnotations;

namespace Betting.Domain.Models
{
    public class User : BaseEntity<Guid>
    {
        [StringLength(100)]
        public string Name { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}