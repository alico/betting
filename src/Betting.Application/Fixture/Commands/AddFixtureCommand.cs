using MediatR;

namespace Betting.Application.Fixture.Commands;
public class AddFixtureCommand : IRequest<Unit>
{
    public Guid SportId { get; set; }
    public Guid CompetitionId { get; set; }
    public string Name { get; set; }
    public List<Guid> Teams { get; set; } = new List<Guid>();
    public List<object> Markets { get; set; } = new List<object> { };
}