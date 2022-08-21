using Betting.Application.Commands.Configuration;
using Betting.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Betting.Infrastructure.Persistance
{
    public class QueryDbContext : BaseDbContext, IQueryDBContext
    {
        public QueryDbContext(IConfigurationManager configurationManager) : base(configurationManager)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configurationManager.DBConnectionString).EnableSensitiveDataLogging();
        }
    }
}
