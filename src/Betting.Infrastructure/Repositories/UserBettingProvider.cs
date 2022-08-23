using Betting.Domain.Contracts;
using Betting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Betting.Infrastructure.Repositories
{
    public class UserBettingProvider : IProvideUserBetting
    {
        private readonly IQueryDBContext _context;
        public UserBettingProvider(IQueryDBContext context)
        {
            _context = context;
        }

        public async Task<List<Bet>> Get(Guid userId, int pageNUmber, int itemCount, CancellationToken cancellationToken)
        {
            //TODO: Create a aggregation model and fill it with only what you need. 
            return await _context.Bets
                                 .Include(x=>x.Fixture)
                                 .Include(x=>x.Fixture.Competition)
                                 .Include(x => x.Fixture.Competition.Sport)
                                 .Include(x => x.Fixture)
                                 .ThenInclude(x => x.FixtureStatus)
                                 .Include(x => x.Fixture.FixtureMarkets)
                                 .Include(x => x.Fixture.Teams)
                                 .ThenInclude(x => x.Team)
                                 .Where(x=>x.UserId == userId)
                                 .Skip((pageNUmber - 1) * itemCount)
                                 .Take(itemCount)
                                 .ToListAsync(cancellationToken);
        }
    }
}
