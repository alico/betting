using MediatR;

namespace Betting.Application.Betting.Queries;
public class ListBettingsQuery : IRequest<IEnumerable<BettingListItemDto>>
{
    public Guid UserId { get; set; }

    public int PageNumber { get; set; } = 1;
    public int ItemCount { get; set; } = 10;
}