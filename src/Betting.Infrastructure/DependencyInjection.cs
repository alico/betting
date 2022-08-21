using Betting.Application.Commands.Configuration;
using Betting.Domain.Contracts;
using Betting.Infrastructure.Configuration;
using Betting.Infrastructure.Persistance;
using Betting.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Betting.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfigurationManager, AppSettingsConfigurationManager>();

            services.AddDbContext<CommandDbContext>(options => options.UseSqlServer(new AppSettingsConfigurationManager(configuration).DBConnectionString), ServiceLifetime.Transient);
            services.AddDbContext<QueryDbContext>(options => options.UseSqlServer(new AppSettingsConfigurationManager(configuration).DBConnectionString), ServiceLifetime.Transient);

            services.AddTransient<ICommandDBContext, CommandDbContext>();
            services.AddTransient<IQueryDBContext, QueryDbContext>();

            services.AddTransient<IProvideFixture, FixtureProvider>();
            services.AddTransient<IProvideMatchPriceMarket, MatchPriceMarketProvider>();
            services.AddTransient<IProvideUserBetting, UserBettingProvider>();

            var serviceProvider = services.BuildServiceProvider();
            var commandContext = serviceProvider.GetService<ICommandDBContext>();

            commandContext.EnsureDbCreated();

            return services;
        }
    }
}
