using Betting.Domain.Contracts;
using MediatR;

namespace Betting.Application.Betting.Queries;
public class ListBettingsQueryHandler : IRequestHandler<ListBettingsQuery, IEnumerable<BettingListItemDto>>
{
    private readonly IProvideUserBetting _provideUserBetting;

    public ListBettingsQueryHandler(IProvideUserBetting provideUserBetting)
    {
        _provideUserBetting = provideUserBetting;
    }
    public async Task<IEnumerable<BettingListItemDto>> Handle(ListBettingsQuery request, CancellationToken cancellationToken)
    {
        //Get user's bettings
        var bettings = await _provideUserBetting.Get(request.UserId, request.PageNumber, request.ItemCount, cancellationToken);

        return bettings.Select(x => new BettingListItemDto()
        {
            FixtureId = x.Id,
            Amount = x.Amount,
            SelectionId = x.SelectionId,
            MarketId = x.MarketId,
            MarketType = (Domain.Enums.MarketType)x.MarketTypeId,
            UserId = x.UserId
        }).ToList();
    }
}