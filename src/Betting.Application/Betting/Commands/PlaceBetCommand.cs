using Betting.Domain.Enums;
using MediatR;

namespace Betting.Application.Bet.Commands;
public class PlaceBetCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid FixtureId { get; set; }
    public Guid MarketId { get; set; }
    public Guid SelectionId { get; set; }
    public MarketType MarketType { get; set; }
    public decimal Amount { get; set; }
}