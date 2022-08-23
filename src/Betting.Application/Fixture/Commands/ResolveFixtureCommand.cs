using MediatR;

namespace Betting.Application.Fixture.Commands;
public class ResolveFixtureCommand : IRequest<Unit>
{
    public Guid FixtureId { get; set; }
}