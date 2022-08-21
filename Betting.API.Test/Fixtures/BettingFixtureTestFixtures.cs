using Betting.Application.Fixture;
using System;
using System.Collections.Generic;

namespace Betting.Test.Fixtures
{
    public static class BettingFixtureTestFixtures
    {
        public static List<FixtureListItemDto> GetTestFixtureList() => new()
        {
            new()
            {
                FixtureId = new Guid("fa97fa89-af1a-4421-a784-50f68f9284d4"),
                Name = "Arsenal vs Chelsea",
                Teams = new List<FixtureTeamListItemDto>()
                {
                    new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Chelsea"
                    },
                      new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Arsenal"
                    }
                },
                Markets = new List<BaseFixtureMarketListItemDto>()
                {
                    new MatchPriceMarketDto()
                    {
                        Id= Guid.NewGuid(),
                        MarketType = Domain.Enums.MarketType.MatchPriceMarket,
                        MarketTypeName = "MatchPriceMarket"
                    }
                }
            },
            new()
            {
                FixtureId = new Guid("48550a4c-adde-452f-998c-fab62fd67680"),
                Name = "Spurs vs Wolves",
                Teams = new List<FixtureTeamListItemDto>()
                {
                    new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Spurs"
                    },
                      new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Wolves"
                    }
                },
                Markets = new List<BaseFixtureMarketListItemDto>()
                {
                    new MatchPriceMarketDto()
                    {
                        Id= Guid.NewGuid(),
                        MarketType = Domain.Enums.MarketType.MatchPriceMarket,
                        MarketTypeName = "MatchPriceMarket",
                    }
                }
            },

            new()
            {
                FixtureId = new Guid("47cee80f-c70a-42a9-86cd-1485e322e386"),
                Name = "Barcelona vs Bayern Munich",
                Teams = new List<FixtureTeamListItemDto>()
                {
                    new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Barcelona"
                    },
                      new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bayern Munich"
                    }
                },
                Markets = new List<BaseFixtureMarketListItemDto>()
                {
                    new MatchPriceMarketDto()
                    {
                        Id= Guid.NewGuid(),
                        MarketType = Domain.Enums.MarketType.MatchPriceMarket,
                        MarketTypeName = "MatchPriceMarket"
                    }
                }
            },
            new()
            {
                FixtureId = new Guid("8ec1d526-bdc2-44c6-9bed-98bca9c69ddb"),
                Name = "Man United vs Monaco",
                Teams = new List<FixtureTeamListItemDto>()
                {
                    new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Man United"
                    },
                      new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Monaco"
                    }
                },
                Markets = new List<BaseFixtureMarketListItemDto>()
                {
                    new MatchPriceMarketDto()
                    {
                        Id= Guid.NewGuid(),
                        MarketType = Domain.Enums.MarketType.MatchPriceMarket,
                        MarketTypeName = "MatchPriceMarket"
                    }
                }
            },

            new()
            {
                FixtureId = new Guid("99442eb7-d26e-455d-b461-4fdca23bf4ed"),
                Name = "Chicago Bulls vs Miami Heat",
                Teams = new List<FixtureTeamListItemDto>()
                {
                    new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Chicago Bulls"
                    },
                      new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Miami Heat"
                    }
                },
                Markets = new List<BaseFixtureMarketListItemDto>()
                {
                    new MatchPriceMarketDto()
                    {
                        Id= Guid.NewGuid(),
                        MarketType = Domain.Enums.MarketType.MatchPriceMarket,
                        MarketTypeName = "MatchPriceMarket"
                    }
                }
            },
            new()
            {
                FixtureId = new Guid("ec84784b-4de2-4b5b-b37d-c09b6676db3f"),
                Name = "Los Angeles Lakers vs Brooklyn Nets",
                Teams = new List<FixtureTeamListItemDto>()
                {
                    new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Los Angeles"
                    },
                      new FixtureTeamListItemDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Brooklyn Nets"
                    }
                },
                Markets = new List<BaseFixtureMarketListItemDto>()
                {
                    new MatchPriceMarketDto()
                    {
                        Id= Guid.NewGuid(),
                        MarketType = Domain.Enums.MarketType.MatchPriceMarket,
                        MarketTypeName = "MatchPriceMarket"
                    }
                }
            }
        };

    }
}
