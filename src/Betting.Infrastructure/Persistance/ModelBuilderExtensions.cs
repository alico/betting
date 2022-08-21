using Betting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Betting.Infrastructure.Persistance;

public static class ModelBuilderExtensions
{
    private static List<Sport> _sports = new()
    {
        new()
        {
            Id = new Guid("214287b9-3a6a-409c-b7f5-2e38aae24e7d"),
            Name = "Football"
        },
        new()
        {
            Id = new Guid("7d72a734-079a-4d46-9a2f-52be2f029947"),
            Name = "NBA"

        },
        //new()
        //{
        //    Id = new Guid("525ea61d-7c95-4288-85cc-1abbd8b30311"),
        //    Title = "The Matrix",
        //    YearOfRelease = 1999,
        //    RunningTime = 180

        //},
        //new()
        //{
        //    Id = new Guid("d248385a-adc8-433b-9b64-36c577410890"),
        //    Title = "The Lord of the Rings: The Two Towers",
        //    YearOfRelease = 2002,
        //    RunningTime = 240

        //},
        //new()
        //{
        //    Id = new Guid("dd943f1d-b52e-480b-ad8c-f83027977db6"),
        //    Title = "Harry Potter and the Sorcerer's Stone",
        //    YearOfRelease = 2001,
        //    RunningTime = 177

        //},
        //new()
        //{
        //    Id = new Guid("6a2de667-93b6-496f-8660-a68ae1bb0614"),
        //    Title = "Fight Club",
        //    YearOfRelease = 1999,
        //    RunningTime = 154

        //},
        //new()
        //{
        //    Id = new Guid("a5ebe0d1-d25f-4cf8-952d-b11289897814"),
        //    Title = "The Sixth Sense",
        //    YearOfRelease = 1999,
        //    RunningTime = 130

        //},
        //new()
        //{
        //    Id = new Guid("cdd3857f-5dd4-4d56-808b-122d20ceffd1"),
        //    Title = "City of Angels",
        //    YearOfRelease = 1999,
        //    RunningTime = 125

        //},
        //new()
        //{
        //    Id = new Guid("0cccdcff-9698-4f3b-8620-c93760f1bf72"),
        //    Title = "Se7en",
        //    YearOfRelease = 1995,
        //    RunningTime = 140

        //},
        //new()
        //{
        //    Id = new Guid("ad781eb5-d144-4155-af5c-740ab066404b"),
        //    Title = "The Usual Suspects",
        //    YearOfRelease = 1995,
        //    RunningTime = 194

        //},
        //new()
        //{
        //    Id = new Guid("69c4d9df-db64-4831-950e-da92dc7501cf"),
        //    Title = "The Silence of the Lambs",
        //    YearOfRelease = 1991,
        //    RunningTime = 115
        //}
    };
    private static List<Competition> _competitions = new()
    {
        new()
        {
            Id = new Guid("cb44773a-8596-4d2c-b4c2-e7894d3f6427"),
            SportId = new Guid("214287b9-3a6a-409c-b7f5-2e38aae24e7d"),
            Name = "Premier League",
        },
        new()
        {
            Id = new Guid("d4a3731b-128b-43b7-8265-313f5d54e9ee"),
            SportId = new Guid("214287b9-3a6a-409c-b7f5-2e38aae24e7d"),
            Name = "Euro League"
        },
        new()
        {
            Id = new Guid("d287dd53-5258-4dc0-a0d7-b58f486c914c"),
            SportId = new Guid("7d72a734-079a-4d46-9a2f-52be2f029947"),
            Name = "NBA"
        },
        //new()
        //{
        //    Id = new Guid("fa97fa89-af1a-4421-a784-50f68f9284d4"),
        //    Name = "Adventure"
        //},
        //new()
        //{
        //    Id = new Guid("48550a4c-adde-452f-998c-fab62fd67680"),
        //    Name = "Science Fiction"
        //},
        //new()
        //{
        //    Id = new Guid("47cee80f-c70a-42a9-86cd-1485e322e386"),
        //    Name = "Fantasy"
        //},
        //new()
        //{
        //    Id = new Guid("8ec1d526-bdc2-44c6-9bed-98bca9c69ddb"),
        //    Name = "Psychological thriller"
        //}
    };
    private static List<Fixture> _fixtures = new()
    {
        //Premier League Fixtures
        new()
        {
            Id = new Guid("fa97fa89-af1a-4421-a784-50f68f9284d4"),
            Name = "Arsenal vs Chelsea",
            CompetitionId = new Guid("cb44773a-8596-4d2c-b4c2-e7894d3f6427"),
            ClosingDate = DateTime.Now.AddDays(10),
            Date = DateTime.Now.AddDays(9),
            FixtureStatusId = (short)Domain.Enums.FixtureStatus.Active
        },
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd67680"),
            Name = "Spurs vs Wolves",
            CompetitionId = new Guid("cb44773a-8596-4d2c-b4c2-e7894d3f6427"),
            ClosingDate = DateTime.Now.AddDays(10),
            Date = DateTime.Now.AddDays(9),
            FixtureStatusId = (short)Domain.Enums.FixtureStatus.Active
        },

        //Europa League Fixtures
        new()
        {
            Id = new Guid("47cee80f-c70a-42a9-86cd-1485e322e386"),
            Name = "Barcelona vs Bayern Munich",
            CompetitionId = new Guid("d4a3731b-128b-43b7-8265-313f5d54e9ee"),
            ClosingDate = DateTime.Now.AddDays(10),
            Date = DateTime.Now.AddDays(9),
            FixtureStatusId = (short)Domain.Enums.FixtureStatus.Active
        },
        new()
        {
            Id = new Guid("8ec1d526-bdc2-44c6-9bed-98bca9c69ddb"),
            Name = "Man United vs Monaco",
            CompetitionId = new Guid("d4a3731b-128b-43b7-8265-313f5d54e9ee"),
            ClosingDate = DateTime.Now.AddDays(10),
            Date = DateTime.Now.AddDays(9),
            FixtureStatusId = (short)Domain.Enums.FixtureStatus.Active
        },

        //NBA Fixtures
        new()
        {
            Id = new Guid("99442eb7-d26e-455d-b461-4fdca23bf4ed"),
            Name = "Chicago Bulls vs Miami Heat",
            CompetitionId = new Guid("d287dd53-5258-4dc0-a0d7-b58f486c914c"),
            ClosingDate = DateTime.Now.AddDays(10),
            Date = DateTime.Now.AddDays(9),
            FixtureStatusId = (short)Domain.Enums.FixtureStatus.Active
        },
        new()
        {
            Id = new Guid("ec84784b-4de2-4b5b-b37d-c09b6676db3f"),
            Name = "Los Angeles Lakers vs Brooklyn Nets",
            CompetitionId = new Guid("d287dd53-5258-4dc0-a0d7-b58f486c914c"),
            ClosingDate = DateTime.Now.AddDays(10),
            Date = DateTime.Now.AddDays(9),
            FixtureStatusId = (short)Domain.Enums.FixtureStatus.Active
        }
    };
    private static List<MarketType> _marketTypes = new()
    {
        new()
        {
            Id = (short)Domain.Enums.MarketType.MatchPriceMarket,
            Name = "MatchPriceMarket"
        }
    };
    private static List<FixtureMarket> _fixtureMarkets = new()
    {
        //PL
        //Arsenal vs Chelsea Markets
        new()
        {
            Id = new Guid("fa97fa89-af1a-4421-a784-50f68f9284b5"),
            FixtureId = new Guid("fa97fa89-af1a-4421-a784-50f68f9284d4"),
            MarketTypeId = (short)Domain.Enums.MarketType.MatchPriceMarket,
        },
        //Spurs vs Wolves Markets
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd67687"),
            FixtureId = new Guid("48550a4c-adde-452f-998c-fab62fd67680"),
            MarketTypeId = (short)Domain.Enums.MarketType.MatchPriceMarket,
        },

        //EL
        //Barcelona vs Bayern Munich
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd67688"),
            FixtureId = new Guid("47cee80f-c70a-42a9-86cd-1485e322e386"),
            MarketTypeId = (short)Domain.Enums.MarketType.MatchPriceMarket,
        },

        //Man United vs Monaco
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd67689"),
            FixtureId = new Guid("8ec1d526-bdc2-44c6-9bed-98bca9c69ddb"),
            MarketTypeId = (short)Domain.Enums.MarketType.MatchPriceMarket,
        },

        //NBA
        //Chicago Bulls vs Miami Heat
        new()
        {
            Id = new Guid("99442eb7-d26e-455d-b461-4fdca23bf4dc"),
            FixtureId = new Guid("99442eb7-d26e-455d-b461-4fdca23bf4ed"),
            MarketTypeId = (short)Domain.Enums.MarketType.MatchPriceMarket,
        },

        //Los Angeles Lakers vs Brooklyn Nets
        new()
        {
            Id = new Guid("ec84784b-4de2-4b5b-b37d-c09b6676db5f"),
            FixtureId = new Guid("ec84784b-4de2-4b5b-b37d-c09b6676db3f"),
            MarketTypeId = (short)Domain.Enums.MarketType.MatchPriceMarket,
        }
    };
    private static List<FixtureTeam> _fixtureTeams = new()
    {
        //PL
        //Arsenal vs Chelsea Markets
        new()
        {
            Id = new Guid("fa97fa89-af1a-4421-a784-50f68f9284b5"),
            FixtureId = new Guid("fa97fa89-af1a-4421-a784-50f68f9284d4"),
            TeamId = new Guid("fa97fa89-af1a-4421-a784-50f68f9365c7"), //Arsenal
        },
        new()
        {
            Id = new Guid("af97fa89-af1a-4421-a784-50f68f9284e8"),
            FixtureId = new Guid("fa97fa89-af1a-4421-a784-50f68f9284d4"),
            TeamId = new Guid("fa97fa89-af1a-4421-a784-50f68f9370b9"), //Chelsea
        },

        //Spurs vs Wolves Markets
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd61675"),
            FixtureId = new Guid("48550a4c-adde-452f-998c-fab62fd67680"),
            TeamId = new Guid("48550a4c-adde-452f-998c-fab62fd65569"), //Spurs
        },
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd17797"),
            FixtureId = new Guid("48550a4c-adde-452f-998c-fab62fd67680"),
            TeamId = new Guid("48550a4c-adde-452f-998c-fab62fd67781"), //Wolves
        },

        //EL
        //Barcelona vs Bayern Munich
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd67644"),
            FixtureId = new Guid("47cee80f-c70a-42a9-86cd-1485e322e386"),
            TeamId = new Guid("48550a4c-adde-452f-998c-fab62fd68522"), //Barcelona
        },
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd62698"),
            FixtureId = new Guid("47cee80f-c70a-42a9-86cd-1485e322e386"),
            TeamId = new Guid("48550a4c-adde-452f-998c-fab62fd64952"), //Bayern Munich
        },

        //Man United vs Monaco
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd62699"),
            FixtureId = new Guid("8ec1d526-bdc2-44c6-9bed-98bca9c69ddb"),
            TeamId = new Guid("48550a4c-adde-452f-998c-fab62fd62177"), //Man United
        },
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd66639"),
            FixtureId = new Guid("8ec1d526-bdc2-44c6-9bed-98bca9c69ddb"),
            TeamId = new Guid("48550a4c-adde-452f-998c-fab62fd63131"), //Monaco
        },

        //NBA
        //Chicago Bulls vs Miami Heat
        new()
        {
            Id = new Guid("98342eb7-d26e-455d-b461-4fdca23bf5ec"),
            FixtureId = new Guid("99442eb7-d26e-455d-b461-4fdca23bf4ed"),
            TeamId = new Guid("99442eb7-d26e-455d-b461-4fdca23bd53c"), //Chicago Bulls 
        },
        new()
        {
            Id = new Guid("94442eb7-d26e-455d-b461-4fdca23bf43c"),
            FixtureId = new Guid("99442eb7-d26e-455d-b461-4fdca23bf4ed"),
            TeamId = new Guid("99442eb7-d26e-455d-b461-4fdca23be3f3"), //Miami Heat
        },

        //Los Angeles Lakers vs Brooklyn Nets
        new()
        {
            Id = new Guid("ec86784b-4de2-4b5b-b37d-c09b6676db5f"),
            FixtureId = new Guid("ec84784b-4de2-4b5b-b37d-c09b6676db3f"),
            TeamId = new Guid("ec84784b-4de2-4b5b-b37d-c09b6676db5f"), //Los Angeles
        },
        new()
        {
            Id = new Guid("ec85784b-4de2-4b5b-b37d-c09b6676db8f"),
            FixtureId = new Guid("ec84784b-4de2-4b5b-b37d-c09b6676db3f"),
            TeamId = new Guid("fe84784b-4de2-4b5b-b37d-c09b6676ed7e"), //Brooklyn Nets
        }
    };
    private static List<Team> _teams = new()
    {
        new()
        {
            Id = new Guid("fa97fa89-af1a-4421-a784-50f68f9365c7"),
            Name = "Arsenal"
        },
        new()
        {
            Id = new Guid("fa97fa89-af1a-4421-a784-50f68f9370b9"),
            Name = "Chelsea"
        },
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd65569"),
            Name = "Spurs"
        },
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd67781"),
            Name = "Wolves"
        },
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd68522"),
            Name = "Barcelona"
        },
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd64952"),
            Name = "Bayern Munich"
        },
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd62177"),
            Name = "Man United"
        },
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd63131"),
            Name = "Monaco"
        },
        new()
        {
            Id = new Guid("99442eb7-d26e-455d-b461-4fdca23bd53c"),
            Name = "Chicago Bulls"
        },
        new()
        {
            Id = new Guid("99442eb7-d26e-455d-b461-4fdca23be3f3"),
            Name = "Miami Heat"
        },

        new()
        {
            Id = new Guid("ec84784b-4de2-4b5b-b37d-c09b6676db5f"),
            Name = "Los Angeles Lakers"
        },
        new()
        {
            Id = new Guid("fe84784b-4de2-4b5b-b37d-c09b6676ed7e"),
            Name = "Brooklyn Nets"
        }
    };
    private static List<User> _users = new()
    {
        new()
        {
            Id = new Guid("72d8d818-a181-4abf-8333-e161bde1db28"),
            Name = "Bob",
        },
        new()
        {
            Id = new Guid("6ca5f829-a543-4d4b-9e59-631f37de72d8"),
            Name = "Jon",
        },
        new()
        {
            Id = new Guid("d06eaf57-6f76-4917-b14f-4fe490f94f4f"),
            Name = "Philip",
        },
    };
    private static List<MatchPriceMarket> _matchPriceMarkets = new()
    {
        //PL
        //Arsenal vs Chelsea Markets
        new()
        {
            Id = new Guid("1a97fa89-af1a-4421-a784-50f68f9284b6"),
            FixtureMarketId = new Guid("fa97fa89-af1a-4421-a784-50f68f9284b5"),
            HomeTeamId = new Guid("fa97fa89-af1a-4421-a784-50f68f9365c7"), //Arsenal,
            AwayTeamId = new Guid("fa97fa89-af1a-4421-a784-50f68f9370b9")
        },

        //Spurs vs Wolves Markets
        new()
        {
            Id = new Guid("58550a4c-adde-452f-998c-fab62fd61676"),
            FixtureMarketId = new Guid("48550a4c-adde-452f-998c-fab62fd67687"),
            HomeTeamId = new Guid("48550a4c-adde-452f-998c-fab62fd67680"),
            AwayTeamId = new Guid("48550a4c-adde-452f-998c-fab62fd67781"),
        },

        //EL
        //Barcelona vs Bayern Munich
        new()
        {
            Id = new Guid("68550a4c-adde-452f-998c-fab62fd67643"),
            FixtureMarketId = new Guid("48550a4c-adde-452f-998c-fab62fd67688"),
            HomeTeamId = new Guid("47cee80f-c70a-42a9-86cd-1485e322e386"),
            AwayTeamId = new Guid("48550a4c-adde-452f-998c-fab62fd64952"),
        },

        //Man United vs Monaco
        new()
        {
            Id = new Guid("78550a4c-adde-452f-998c-fab62fd62691"),
            FixtureMarketId = new Guid("48550a4c-adde-452f-998c-fab62fd67689"),
            HomeTeamId = new Guid("48550a4c-adde-452f-998c-fab62fd62177"),
            AwayTeamId = new Guid("48550a4c-adde-452f-998c-fab62fd63131"),
        },

        //NBA
        //Chicago Bulls vs Miami Heat
        new()
        {
            Id = new Guid("88342eb7-d26e-455d-b461-4fdca23bf5ea"),
            FixtureMarketId = new Guid("99442eb7-d26e-455d-b461-4fdca23bf4dc"),
            HomeTeamId = new Guid("99442eb7-d26e-455d-b461-4fdca23bd53c"),
            AwayTeamId = new Guid("48550a4c-adde-452f-998c-fab62fd63131"),

        },

        //Los Angeles Lakers vs Brooklyn Nets
        new()
        {
            Id = new Guid("1c86784b-4de2-4b5b-b37d-c09b6676db6e"),
            FixtureMarketId = new Guid("ec84784b-4de2-4b5b-b37d-c09b6676db5f"),
            HomeTeamId = new Guid("ec84784b-4de2-4b5b-b37d-c09b6676db5f"),
            AwayTeamId = new Guid("fe84784b-4de2-4b5b-b37d-c09b6676ed7e"),
        },
    };
    private static List<MatchPriceSelectionType> _matchPriceOddTypes = new()
    {
        new()
        {
            Id = (short)Domain.Enums.MatchPriceSelectionType.HomeTeamWins,
            Name = "Home team wins"
        },
        new()
        {
            Id = (short)Domain.Enums.MatchPriceSelectionType.AwayTeamWins,
            Name = "Away team wins"
        },
        new()
        {
            Id = (short)Domain.Enums.MatchPriceSelectionType.Draw,
            Name = "Draw"
        }
    };
    private static List<MatchPriceSelection> _matchPriceOdds = new()
    {
        //PL
        //Arsenal vs Chelsea MatchPriceMarket Odds
        new()
        {
            Id = new Guid("2a98fa89-af1a-4421-a784-50f68f9285c7"),
            MatchPriceMarketId = new Guid("1a97fa89-af1a-4421-a784-50f68f9284b6"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.HomeTeamWins,
            Odds = 1.80
        },
        new()
        {
            Id = new Guid("2a98fa89-af1a-4421-a784-50f68f9285c8"),
            MatchPriceMarketId = new Guid("1a97fa89-af1a-4421-a784-50f68f9284b6"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.AwayTeamWins,
            Odds = 2.80
        },
        new()
        {
            Id = new Guid("2a98fa89-af1a-4421-a784-50f68f9285c9"),
            MatchPriceMarketId = new Guid("1a97fa89-af1a-4421-a784-50f68f9284b6"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.Draw,
            Odds = 2.10
        },

        //Spurs vs Wolves Markets
        new()
        {
            Id = new Guid("58550a4c-adde-452f-998c-fab62fd61675"),
            MatchPriceMarketId = new Guid("58550a4c-adde-452f-998c-fab62fd61676"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.HomeTeamWins,
            Odds = 1.20
        },
        new()
        {
            Id = new Guid("58550a4c-adde-452f-998c-fab62fd61674"),
            MatchPriceMarketId = new Guid("58550a4c-adde-452f-998c-fab62fd61676"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.AwayTeamWins,
            Odds = 2.95
        },
        new()
        {
            Id = new Guid("58550a4c-adde-452f-998c-fab62fd61673"),
            MatchPriceMarketId = new Guid("58550a4c-adde-452f-998c-fab62fd61676"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.Draw,
            Odds = 1.85
        },

        //EL
        //Barcelona vs Bayern Munich
        new()
        {
            Id = new Guid("48550a4c-adde-452f-998c-fab62fd67647"),
            MatchPriceMarketId = new Guid("68550a4c-adde-452f-998c-fab62fd67643"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.HomeTeamWins,
            Odds = 1.30
        },
        new()
        {
            Id = new Guid("58550a4c-adde-452f-998c-fab62fd67648"),
            MatchPriceMarketId = new Guid("68550a4c-adde-452f-998c-fab62fd67643"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.AwayTeamWins,
            Odds = 2.0
        },
        new()
        {
            Id = new Guid("28550a4c-adde-452f-998c-fab62fd67649"),
            MatchPriceMarketId = new Guid("68550a4c-adde-452f-998c-fab62fd67643"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.Draw,
            Odds = 1.40
        },

        //Man United vs Monaco
        new()
        {
            Id = new Guid("34550a4c-adde-452f-998c-fab62fd62624"),
            MatchPriceMarketId = new Guid("78550a4c-adde-452f-998c-fab62fd62691"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.HomeTeamWins,
            Odds = 1.20
        },
        new()
        {
            Id = new Guid("15550a4c-adde-452f-998c-fab62fd62658"),
            MatchPriceMarketId = new Guid("78550a4c-adde-452f-998c-fab62fd62691"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.AwayTeamWins,
            Odds = 2.20
        },
        new()
        {
            Id = new Guid("31550a4c-adde-452f-998c-fab62fd62669"),
            MatchPriceMarketId = new Guid("78550a4c-adde-452f-998c-fab62fd62691"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.Draw,
            Odds = 1.90
        },

        //NBA
        //Chicago Bulls vs Miami Heat
        new()
        {
            Id = new Guid("78342eb7-d26e-455d-b461-4fdca23bf4ea"),
            MatchPriceMarketId = new Guid("88342eb7-d26e-455d-b461-4fdca23bf5ea"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.HomeTeamWins,
            Odds = 1.10

        },
        new()
        {
            Id = new Guid("85342eb7-d26e-455d-b461-4fdca23bf3ea"),
            MatchPriceMarketId = new Guid("88342eb7-d26e-455d-b461-4fdca23bf5ea"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.AwayTeamWins,
            Odds = 3.10

        },
        new()
        {
            Id = new Guid("86342eb7-d26e-455d-b461-4fdca23bf5aa"),
            MatchPriceMarketId = new Guid("88342eb7-d26e-455d-b461-4fdca23bf5ea"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.Draw,
            Odds = 2.10
        },

        //Los Angeles Lakers vs Brooklyn Nets
        new()
        {
            Id = new Guid("9286784b-4de2-4b5b-b37d-c09b6676db7b"),
            MatchPriceMarketId = new Guid("1c86784b-4de2-4b5b-b37d-c09b6676db6e"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.HomeTeamWins,
            Odds = 1.10
        },
        new()
        {
            Id = new Guid("2286784b-4de2-4b5b-b37d-c09b6676db6c"),
            MatchPriceMarketId = new Guid("1c86784b-4de2-4b5b-b37d-c09b6676db6e"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.AwayTeamWins,
            Odds = 2.10
        },
        new()
        {
            Id = new Guid("3186784b-4de2-4b5b-b37d-c09b6676db8a"),
            MatchPriceMarketId = new Guid("1c86784b-4de2-4b5b-b37d-c09b6676db6e"),
            MatchPriceSelectionTypeId = (short)Domain.Enums.MatchPriceSelectionType.Draw,
            Odds = 3.90
        },
    };
    private static List<FixtureStatus> _fixtureStatuses = new()
    {
        new()
        {
            Id = (short)Domain.Enums.FixtureStatus.Active,
            Name = "Active"
        },
        new()
        {
            Id = (short)Domain.Enums.FixtureStatus.Finished,
            Name = "Finished"
        },
        new()
        {
            Id = (short)Domain.Enums.FixtureStatus.Cancelled,
            Name = "Cancelled"
        }
    };
    private static List<BetSettlement> _betStatuses= new()
    {
        new()
        {
            Id = (short)Domain.Enums.BetSettlement.Active,
            Name = "Active"
        },
        new()
        {
            Id = (short)Domain.Enums.BetSettlement.Won,
            Name = "Won"
        },
        new()
        {
            Id = (short)Domain.Enums.BetSettlement.Lost,
            Name = "Lost"
        },
        new()
        {
            Id = (short)Domain.Enums.BetSettlement.Void,
            Name = "Lost"
        }
    };

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sport>().HasData(_sports);
        modelBuilder.Entity<Competition>().HasData(_competitions);
        modelBuilder.Entity<Fixture>().HasData(_fixtures);
        modelBuilder.Entity<MarketType>().HasData(_marketTypes);
        modelBuilder.Entity<Team>().HasData(_teams);
        modelBuilder.Entity<User>().HasData(_users);
        modelBuilder.Entity<FixtureMarket>().HasData(_fixtureMarkets);
        modelBuilder.Entity<FixtureTeam>().HasData(_fixtureTeams);
        modelBuilder.Entity<MatchPriceMarket>().HasData(_matchPriceMarkets);
        modelBuilder.Entity<MatchPriceSelectionType>().HasData(_matchPriceOddTypes);
        modelBuilder.Entity<MatchPriceSelection>().HasData(_matchPriceOdds);
        modelBuilder.Entity<FixtureStatus>().HasData(_fixtureStatuses);
        modelBuilder.Entity<BetSettlement>().HasData(_betStatuses);
    }
}
