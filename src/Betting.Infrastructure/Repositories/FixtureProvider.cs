using Betting.Domain.Contracts;
using Betting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Betting.Infrastructure.Repositories
{
    public class FixtureProvider : IProvideFixture
    {
        private readonly IQueryDBContext _context;
        public FixtureProvider(IQueryDBContext context)
        {
            _context = context;
        }

        public async Task<List<Fixture>> GetFixtures(Expression<Func<Fixture, bool>> expression, int pageNUmber, int itemCount, CancellationToken cancellationToken)
        {
            return await _context.Fixtures
                                   .Include(x => x.FixtureMarkets)
                                   .Include(x => x.Teams)
                                   .ThenInclude(x => x.Team)
                                   .Where(expression)
                                   .Skip((pageNUmber - 1) * itemCount)
                                   .Take(itemCount)
                                   .ToListAsync(cancellationToken);
        }
    }
}
