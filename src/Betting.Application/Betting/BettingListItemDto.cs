﻿using Betting.Domain.Enums;

namespace Betting.Application.Betting;

public class BettingListItemDto
{
    public Guid UserId { get; set; }
    public Guid FixtureId { get; set; }
    public Guid MarketId { get; set; }
    public Guid SelectionId { get; set; }
    public MarketType MarketType { get; set; }
    public decimal Amount { get; set; }
}