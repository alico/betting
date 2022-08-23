using Betting.Application.Common.Exceptions;
using Betting.Domain.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Betting.Application.Betting.Commands;
public class PlaceBetCommandHandler : IRequestHandler<PlaceBetCommand, Guid>
{
    private readonly ICommandDBContext _context;
    private readonly IProvideMatchPriceMarket _matchPriceMarketProvider;
    public PlaceBetCommandHandler(IProvideMatchPriceMarket matchPriceMarketProvider, ICommandDBContext context)
    {
        _matchPriceMarketProvider = matchPriceMarketProvider;
        _context = context;
    }
    public async Task<Guid> Handle(PlaceBetCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Users.AnyAsync(x => x.Id == request.UserId))
            throw new CustomException($"User {request.UserId} has not been found.");

        var market = await _matchPriceMarketProvider.Get(request.MarketId, cancellationToken);

        if (market is null)
            throw new CustomException($"Fixture {request.MarketId} has not been found.");

        if (!market.MatchPriceSelections.Any(x => x.Id == request.SelectionId))
            throw new CustomException($"Selection {request.SelectionId} has not been found.");

        if (market.FixtureMarket.Fixture.FixtureStatusId != (short)Domain.Enums.FixtureStatus.Active)
            throw new CustomException($"Fixture {request.FixtureId} is closed for betting.");

        if (market.FixtureMarket.Fixture.ClosingDate < DateTime.UtcNow)
            throw new CustomException($"Fixture {request.FixtureId} is closed for betting.");

        var bet = new Domain.Models.Bet()
        {
            UserId = request.UserId,
            FixtureId = request.FixtureId,
            MarketId = request.MarketId,
            SelectionId = request.SelectionId,
            Amount = request.Amount,
            MarketTypeId = (short)request.MarketType,
        };

        _context.Bets.Add(bet);
        await _context.SaveChangesAsync(cancellationToken);

        return bet.Id;
    }
}