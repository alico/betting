using MediatR;

namespace Betting.Application.Fixture.Queries;
public class ListFixturesQuery : IRequest<IEnumerable<FixtureListItemDto>>
{
    public Guid? SportId { get; set; }
    public Guid? CompetitionId { get; set; }
    public Guid? FixtureId { get; set; }

    public int PageNumber { get; set; } = 1;
    public int ItemCount { get; set; } = 10;
}