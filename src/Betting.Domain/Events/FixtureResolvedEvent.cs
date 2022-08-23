using MediatR;

namespace Betting.Domain.Events
{
    public class FixtureResolvedEvent : INotification
    {
        public Guid FixtureId { get; internal set; }

        public FixtureResolvedEvent(Guid fixtureId)
        {
            FixtureId = fixtureId;
        }
    }
}
