using Betting.Domain.Models;
using System.Linq.Expressions;

namespace Betting.Domain.Contracts;
public interface IProvideFixture
{
    Task<List<Fixture>> GetFixtures(Expression<Func<Fixture, bool>> expression, int pageNUmber, int itemCount, CancellationToken cancellationToken);
}