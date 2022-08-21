using Betting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Betting.Domain.Contracts;
public interface IDbContext
{
    public DbSet<Sport> Sports { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Fixture> Fixtures { get; set; }
    public DbSet<FixtureMarket> FixtureMarkets { get; set; }
    public DbSet<FixtureTeam> FixtureTeams { get; set; }
    public DbSet<MarketType> MarketTypes { get; set; }
    public DbSet<MatchPriceMarket> MatchPriceMarket { get; set; }
    public DbSet<MatchPriceSelection> MatchPriceSelections { get; set; }
    public DbSet<MatchPriceSelectionType> MatchPriceSelectionTypes { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Bet> Bets { get; set; }

    //Create an initial database
    bool EnsureDbCreated();
}
