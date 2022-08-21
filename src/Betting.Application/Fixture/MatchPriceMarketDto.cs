using AutoMapper;
using Betting.Application.Common.Mappings;
using Betting.Domain.Enums;

namespace Betting.Application.Fixture;

public class MatchPriceMarketDto : BaseFixtureMarketListItemDto, IMapFrom<Domain.Models.MatchPriceMarket>
{
    public Guid HomeTeam { get; set; }
    public Guid AwayTeam { get; set; }
    public List<MatchPriceMarketSelectionListItemDto> Selections { get; set; } = new List<MatchPriceMarketSelectionListItemDto>();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Models.MatchPriceMarket, MatchPriceMarketDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.FixtureId, opt => opt.MapFrom(s => s.FixtureMarket.FixtureId))
            .ForMember(d => d.AwayTeam, opt => opt.MapFrom(s => s.AwayTeamId))
            .ForMember(d => d.HomeTeam, opt => opt.MapFrom(s => s.HomeTeamId))
            .ForMember(d => d.MarketType, opt => opt.MapFrom(s => (MarketType)s.FixtureMarket.MarketTypeId))
            .ForMember(d => d.MarketTypeName, opt => opt.MapFrom(s => s.FixtureMarket.MarketType.Name))
            .ForMember(d => d.Selections, opt => opt.MapFrom(s => s.MatchPriceSelections.Select(y => new MatchPriceMarketSelectionListItemDto()
            {
                Id = y.Id,
                SelectionType = (MatchPriceSelectionType)y.MatchPriceSelectionTypeId,
                SelectionTypeName = y.MatchPriceSelectionType.Name,
                Value = y.Odds
            }).ToList()));
    }
}
