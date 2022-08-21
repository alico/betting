using Betting.Application.Commands.Configuration;
using Betting.Domain.Contracts;
using Betting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Betting.Infrastructure.Persistance;
public class CommandDbContext : BaseDbContext, ICommandDBContext
{
    public CommandDbContext(IConfigurationManager configurationManager) : base(configurationManager)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_configurationManager.DBConnectionString).EnableSensitiveDataLogging();
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var item in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
        {
            if (item.State is EntityState.Modified or EntityState.Added)
                item.Entity.LastModifyDate = DateTime.Now;

            if (item.State is EntityState.Added)
                item.Entity.CreationDate = DateTime.Now;
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}

