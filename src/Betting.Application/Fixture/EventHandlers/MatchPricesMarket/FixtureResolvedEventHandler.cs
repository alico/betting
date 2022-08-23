using Betting.Domain.Contracts;
using Betting.Domain.Enums;
using Betting.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Betting.Application.Fixture.EventHandlers.MatchPricesMarket;
public class FixtureResolvedEventHandler : INotificationHandler<FixtureResolvedEvent>
{
    private readonly ICommandDBContext _commandDBContext;

    public FixtureResolvedEventHandler(ICommandDBContext commandDBContext)
    {
        _commandDBContext = commandDBContext;
    }

    public async Task Handle(FixtureResolvedEvent notification, CancellationToken cancellationToken)
    {
        var selections = await _commandDBContext.MatchPriceSelections
                                         .Include(x => x.Market)
                                         .ThenInclude(x => x.FixtureMarket)
                                         .Where(x => x.Market.FixtureMarket.FixtureId == notification.FixtureId)
                                         .ToListAsync(cancellationToken);

        if (selections?.Count > 0)
        {
            int index = new Random().Next(selections.Count);

            for (int i = 0; i < selections.Count; i++)
            {
                selections[i].SettlementId = i == index ? (short)Settlement.Won : (short)Settlement.Lost;
            }

            await _commandDBContext.SaveChangesAsync(cancellationToken);
        }
    }
}