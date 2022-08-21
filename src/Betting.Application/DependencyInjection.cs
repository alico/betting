using Betting.Application.Common.Behaviours;
using Betting.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Betting.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IListFixturesExpressionBuilder, ListFixturesExpressionBuilder>();
            services.AddTransient<IFixtureMarketService, FixtureMarketService>();

            return services;
        }
    }
}
