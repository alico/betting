using Betting.Domain.Models;
using System.Linq.Expressions;

namespace Betting.Domain.Contracts;
public interface IProvideUserBetting
{
    Task<List<Bet>> Get(Guid userId, int pageNUmber, int itemCount, CancellationToken cancellationToken);
}