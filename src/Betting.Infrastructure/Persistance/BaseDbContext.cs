using Betting.Application.Commands.Configuration;
using Betting.Domain.Contracts;
using Betting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Betting.Infrastructure.Persistance;
public abstract class BaseDbContext : DbContext, IDbContext
{
    protected readonly IConfigurationManager _configurationManager;
    public BaseDbContext(IConfigurationManager configurationManager)
    {
        _configurationManager = configurationManager;
    }
    public BaseDbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Sport>().HasKey(x => x.Id);
        modelBuilder.Entity<Competition>().HasKey(x => x.Id);
        modelBuilder.Entity<Fixture>().HasKey(x => x.Id);
        modelBuilder.Entity<FixtureMarket>().HasKey(x => x.Id);
        modelBuilder.Entity<FixtureTeam>().HasKey(x => x.Id);
        modelBuilder.Entity<MarketType>().HasKey(x => x.Id);
        modelBuilder.Entity<MatchPriceMarket>().HasKey(x => x.Id);
        modelBuilder.Entity<MatchPriceSelection>().HasKey(x => x.Id);
        modelBuilder.Entity<MatchPriceSelectionType>().HasKey(x => x.Id);
        modelBuilder.Entity<Team>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<Bet>().HasKey(x => x.Id);


        modelBuilder.Entity<Sport>().HasMany(x => x.Competitions);
        modelBuilder.Entity<Competition>().HasOne(x => x.Sport);
        modelBuilder.Entity<Competition>().HasMany(x => x.Fixtures);
        modelBuilder.Entity<Fixture>().HasOne(x => x.Competition);
        modelBuilder.Entity<Fixture>().HasMany(x => x.FixtureMarkets);
        modelBuilder.Entity<Fixture>().HasMany(x => x.Teams);
        modelBuilder.Entity<Fixture>().HasOne(x => x.FixtureStatus);
        modelBuilder.Entity<FixtureMarket>().HasOne(x => x.MarketType);
        modelBuilder.Entity<FixtureTeam>().HasOne(x => x.Fixture);
        modelBuilder.Entity<FixtureTeam>().HasOne(x => x.Team);
        modelBuilder.Entity<MatchPriceSelection>().HasOne(x => x.Market);
        modelBuilder.Entity<MatchPriceSelection>().HasOne(x => x.MatchPriceSelectionType);
        modelBuilder.Entity<MatchPriceMarket>().HasOne(x => x.FixtureMarket);
        modelBuilder.Entity<MatchPriceMarket>().HasMany(x => x.MatchPriceSelections);
        modelBuilder.Entity<Bet>().HasOne(x => x.User);
        modelBuilder.Entity<Bet>().HasOne(x => x.Fixture);
        modelBuilder.Entity<Bet>().HasOne(x => x.BetSettlement);
        modelBuilder.Entity<User>().HasMany(x => x.Bets);

        modelBuilder.Seed();
    }


    public bool EnsureDbCreated()
    {
        return this.Database.EnsureCreated();
    }

    public DbSet<Sport> Sports { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Fixture> Fixtures { get; set; }
    public DbSet<FixtureStatus> FixtureStatuses { get; set; }
    public DbSet<FixtureMarket> FixtureMarkets { get; set; }
    public DbSet<FixtureTeam> FixtureTeams { get; set; }
    public DbSet<MarketType> MarketTypes { get; set; }
    public DbSet<MatchPriceMarket> MatchPriceMarket { get; set; }
    public DbSet<MatchPriceSelection> MatchPriceSelections { get; set; }
    public DbSet<MatchPriceSelectionType> MatchPriceSelectionTypes { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Bet> Bets { get; set; }
    public DbSet<BetSettlement> BetSettlements { get; set; }

}
